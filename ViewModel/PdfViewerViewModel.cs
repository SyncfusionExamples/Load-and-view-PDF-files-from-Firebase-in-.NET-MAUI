using Firebase.Storage;
using System.ComponentModel;

namespace Firebase_PdfViewerExample
{
    internal class PdfViewerViewModel : INotifyPropertyChanged
    {
        private static string storageBucket = "<STORAGE BUCKET NAME>";

        private static string fileName = "<FILE NAME>";

        private Stream? m_pdfDocumentStream;

        /// <summary>
        /// An event to detect the change in the value of a property.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// The PDF document stream that is loaded into the instance of the PDF viewer. 
        /// </summary>
        public Stream PdfDocumentStream
        {
            get
            {
                return m_pdfDocumentStream;
            }
            set
            {
                m_pdfDocumentStream = value;
                OnPropertyChanged("PdfDocumentStream");
            }
        }

        /// <summary>
        /// Constructor of the view model class
        /// </summary>
        public PdfViewerViewModel()
        {
            LoadPDFFromFirebaseStorage();
        }

        /// <summary>
        /// Load the PDF document from the Firebase storage
        /// </summary>
        public async void LoadPDFFromFirebaseStorage()
        {
            HttpClient httpClient = new HttpClient();

            FirebaseStorage storage = new FirebaseStorage(storageBucket);

            string documentUrl = await storage.Child(fileName).GetDownloadUrlAsync();

            HttpResponseMessage response = await httpClient.GetAsync(documentUrl);

            PdfDocumentStream = await response.Content.ReadAsStreamAsync();
        }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
