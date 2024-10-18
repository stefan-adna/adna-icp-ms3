# MS3: Storage Engine Prototype
Objectives: 
* To develop a prototype demonstrating the feasibility and benefits of  integrating Canister Technology with the A.DNA Data Vault by using ICP.NET.

Deliverables:
* A working prototype of the A.DNA Data Vault integrated with Canister Technology.

## Implementation

We have refactored the `DocumentBll.cs` to allow documents to be uploaded and received from an ICP asset cannister. Because the A.DNA Software is closed source at this moment we cannot share any more code related.

```
private async Task UploadRevision(DocumentRevision documentRevision, Guid companyId) 
{
    //store document in icp
    await _icpConnector.UploadDocument(documentRevision.Id.ToString().ToLower(), documentRevision.Data);
}

private async Task GetRevision(DocumentRevision documentRevision) 
{
    //retrieve document from icp
    var assetFromCannister = await _icpConnector.DownloadDocument(documentRevision.Id.ToString().ToLower());
}
```

## Usage

The whole process happens transparent to the user. The A.DNA data vault administrator can choose if he wants to use our storage server or the ICP in the settings page. The A.DNA server is communicating with the ICP cannister in the background and serving the files directly to the user as usual. The response times for uploading and downloading files via ICP are a bit slower but acceptable.