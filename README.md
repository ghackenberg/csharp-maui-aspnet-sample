# C# MAUI.NET / ASP.NET Sample

**This project contains a sample application based on the awesome Microsoft MAUI.NET and ASP.NET frameworks.**

<img src="./Screenshots/CustomApp-Users.png" height="150" />&Tab;<img src="./Screenshots/CustomApp-User.png" height="150" />&Tab;<img src="./Screenshots/CustomApi.png" height="150" />

We use this sample project at the [School of Engineering](https://www.fh-ooe.at/campus-wels/) of the [University of Applied Sciences Upper Austria](https://www.fh-ooe.at/) in [Wels, Austria](https://www.wels.at/) for teaching courses in **Mobile and Cloud Computing** to our engineering and management students. Since we mainly use C# as a language and DotNet as a framework in our programming courses in the earlier semester, we decided to use the  MAUI.NET and ASP.NET frameworks in this course. The MAUI.NET and ASP.NET frameworks provide the following capabilities:

- [MAUI.NET](https://dotnet.microsoft.com/en-us/apps/maui) supports building **cross-platfrom graphical user interfaces (GUIs)**.
- [ASP.NET](https://dotnet.microsoft.com/en-us/apps/aspnet) supports building **Cloud services with state-of-the-art REST APIs**.

## 📝 Guides

The following set of guides helps you **getting started with MAUI.NET and ASP.NET development on your local machine**. Note that the guides have been prepared for Windows machines only. In principle, MAUI.NET and ASP.NET development should be possible also on OS X and Linux machines. However, we did not test that.

1. [**Fork the respository** of the sample application](./Guides/0_Fork.md)
2. [**Prepare your development environment**](./Guides/1_Prepare.md)
3. [**Clone the sources** of the sample application](./Guides/2_Clone.md)
4. [**Build and run** the sample application](./Guides/3_Run.md)
5. [**Make changes** to the sample application](./Guides/4_Change.md)

## 📸 Screenshots

In the following, we provide screenshots of the sample application to give a first impression of its functionality. The following screenshots are included:

1. **MAUI.NET Users Page** provides a list of existing users
2. **MAUI.NET User Page** provides details of one user
3. **ASP.NET Swagger UI** provides the REST API documentation

### MAUI.NET Users Page

The **MAUI.NET Users Page** provides a list of existing users, allows you to reload the list of existing users, and provides means for editing existing users or creating new users. The users are retrieved from the backend service.

![MAUI.NET / ASP.NET Sample Users Screenshot](./Screenshots/CustomApp-Users.png)

### MAUI.NET User Page

The **MAUI.NET User Page** provides means for editing the information of existing users or entering the information of new users and sending the information to the Cloud-based backend services for long-term storage.

![MAUI.NET / ASP.NET Sample User Screenshot](./Screenshots/CustomApp-User.png)

### ASP.NET Swagger UI

The **ASP.NET Swagger UI** provides a documentation of the Cloud-based backend services, which are exposed via HTTP REST API. For each endpoint, the expected inputs and provided outputs are shown including examples.

![MAUI.NET / ASP.NET Sample User Screenshot](./Screenshots/CustomApi.png)

## 📈 Structures

In the following, we explain internal structures of the sample application. We divided the expanation into the following subsections:

1. **Package structure** describes the C# packages (i.e. DLLs and EXEs) and their relations.
2. **Data structure** describes the database entities, their attributes, and their relations.
3. **Message structure** describes the structure of the HTTP request and response messages.
4. **Interface structure** describes the interfaces and methods of the backend services.

### Package structure

The following diagram explains the package structure of the sample application. The package structure consists of three projects: A MAUI.NET application project, an ASP.NET werb service project, and a common class library project. Furthermore, the MAUI.NET application communicates with the ASP.NET web service via HTTP REST protocol.

![MAUI.NET / ASP.NET Sample Package Structure](./Models/Package.svg)

### Data structure

The following diagram explains the data structrure of the sample application: The data structure consists of three classes: A user class representing the users of the application, an issue class representing the issues created by the users, and a comment class representing comments created by the users and contained in issues.

![MAUI.NET / ASP.NET Sample Data Structure](./Models/Data.svg)

### Message structure

The following diagram explains the message structure of the sample application used for communication between the graphical user interface and the service via HTTP REST. For each entity (i.e. user, issue, comment), the structure of the HTTP responses as well as the HTTP POST and HTTP PUT requests are described.

![MAUI.NET / ASP.NET Sample Message Structure](./Models/Message.svg)

### Interface structure

The following diagram explains the interface structure of the sample application. For each entity (i.e. user, issue, comment), methods are provided for listing all existing entity instances, creating a new instance, getting an existing instance, updating an existing instance, and deleting an existing instance.

![MAUI.NET / ASP.NET Sample Interface Structure](./Models/Interface.svg)