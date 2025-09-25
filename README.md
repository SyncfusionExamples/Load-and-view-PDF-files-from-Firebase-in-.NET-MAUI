# Load-and-view-PDF-files-from-Firebase-in-.NET-MAUI
This repository contains the example which demonstrates how to access PDF files from the Firebase clous storage and view them using Syncfusion&reg; .NET MAUI PDF Viewer.

## Overview of Firebase Storage Interaction
The above example primary goal is to download a PDF file from your Firebase Cloud Storage and convert it into a Stream that the Syncfusion SfPdfViewer can understand. It does this in two main phases:

**Get Download URL:** It communicates with Firebase to get a unique, temporary, and secure URL for the requested file.

**Download the File:** It uses a standard HttpClient to download the file's content from that URL.
This approach is common and secure because you don't need to embed any secret API keys or credentials directly in your application code. The FirebaseStorage.net library handles the authentication required to generate the URL behind the scenes (often using the configuration you provide in your Firebase project setup, like the google-services.json file for Android).

### 1. Namespace and Dependencies
First, the code imports the necessary library. The [FirebaseStorage.net](https://www.nuget.org/packages/FirebaseStorage.net/) NuGet package provides the Firebase.Storage namespace.

```
using Firebase.Storage;
```

This line gives you access to the FirebaseStorage class, which is the entry point for all interactions with your storage bucket.

### 2. Configuration Variables

These two private fields are where you configure the connection to your specific Firebase project.

```
private static string storageBucket = "<STORAGE BUCKET NAME>";
private static string fileName = "<FILE NAME>";
```

storageBucket: This is the address of your Firebase Storage bucket. You can find this in your Firebase Console. It typically follows the format your-project-id.appspot.com.
fileName: This is the name of the file you want to download. If the file is in a folder, you must include the full path, for example, invoices/invoice-123.pdf.

### 3. The LoadPDFFromFirebaseStorage() Method

This method contains the core logic for the download process. It is marked as async void because it performs network operations that should not block the UI thread.

```
public async void LoadPDFFromFirebaseStorage()
{
    // 1. Create an instance of an HTTP client
    HttpClient httpClient = new HttpClient();
    // 2. Instantiate the FirebaseStorage object with your bucket
    FirebaseStorage storage = new FirebaseStorage(storageBucket);
    // 3. Get a secure download URL for the specified file
    string documentUrl = await storage.Child(fileName).GetDownloadUrlAsync();
    // 4. Use the HTTP client to download the file from the URL
    HttpResponseMessage response = await httpClient.GetAsync(documentUrl);
    // 5. Read the content of the response as a Stream
    PdfDocumentStream = await response.Content.ReadAsStreamAsync();
}
```

### Conclusion

We hope you enjoyed learning how to Load and view PDF files from Firebase in .NET-MAUI PDF Viewer

Refer to our [.NET MAUI PDF Viewer’s feature tour](https://www.syncfusion.com/maui-controls/maui-pdf-viewer) page to learn about its other groundbreaking feature representations. You can also explore our [.NET MAUI PDF Viewer Documentation](https://help.syncfusion.com/maui/pdf-viewer/getting-started) to understand how to present and manipulate data.

For current customers, check out our .NET MAUI components on the [License and Downloads](https://www.syncfusion.com/sales/teamlicense) page. If you are new to Syncfusion, try our 30-day [free trial](https://www.syncfusion.com/downloads/maui) to explore our .NET MAUI PDF Viewer and other .NET MAUI components.

Please let us know in the following comments if you have any queries or require clarifications. You can also contact us through our [support forums](https://www.syncfusion.com/downloads/maui), [support ticket](https://support.syncfusion.com/create) or [feedback portal](https://www.syncfusion.com/feedback/maui). We are always happy to assist you!
