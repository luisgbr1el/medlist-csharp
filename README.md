# medlist-csharp
Code that asks info about doctors and at the end, creates a `.html` "webpage" with a `<table>` listing all data.

### Resources
- C#
- Some HTML in C# code


### Default path
The default path to the code is `C:\temp\`.

### Default file name
The default file name to the `.html` file is `summaryDoctors_ddMMyyyy_HHmmss.html`, generated with the following code:
```c#
string path = "C:\\temp";
string fileName = "\\summaryDoctors";
DateTime datetime = DateTime.Now;

string fullName = path + fileName + "_" + datetime.ToString("ddMMyyyy_HHmmss") + ".html";
```
  
  
### Generated webpage
![image](https://user-images.githubusercontent.com/62726888/156799270-a787930b-2a45-4408-ba32-5bcdeefa4789.png)
