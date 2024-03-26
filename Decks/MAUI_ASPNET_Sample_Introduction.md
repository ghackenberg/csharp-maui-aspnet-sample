---
marp: true
theme: CustomTheme
header: C# MAUI.NET / ASP.NET Sample Application
footer: Dr. Georg Hackenberg | Professor for Industrial Informatics | FH OÖ
paginate: true
---

<!-- _class: center hide-header hide-footer hide-page-number -->

# C# MAUI.NET / ASP.NET Sample Application

**Dr. Georg Hackenberg BSc MSc**

Professor for Industrial Informatics | School of Engineering
University of Applied Sciences Upper Austria
Stelzhamerstr. 23, 4600 Wels, Austria

👤 https://github.com/ghackenberg
👤 https://linkedin.com/in/georghackenberg
👤 https://youtube.com/@georghackenberg

Also check out https://mentawise.com and https://caddrive.org 😎

---

<!-- _class: hide-page-number -->

![bg right:40% w:150%](../Images/MAUI_ASPNET_Sample_Deck_Preview_Image.png)

## Deck overview


- **Section 1 - The software architecture**
- **Section 2 - The `CustomLib` component**
- **Section 3 - The `CustomApi` component**
- **Section 4 - The `CustomSdk` component**
- **Section 5 - The `CustomCli` component**
- **Section 6 - The `CustomApp` component**
- **Section 7 - The follow-up resources**

---

<!-- _class: center dark -->

## Section 1 - The software architecture

**Domain** and **component model**

---

<!-- _class: center -->

### Domain model

The **entities**, their **attributes**, and their **relationships**

---

![bg right w:90%](../Models/Data/Overview.png)

#### Domain model overview

The diagram on the right shows the **domain model** implemented by the application.

The data model consists of **three entities**, namely `User`, `Issue`, and `Comment`.

Issues and comments are `created by` users, comments are `contained in` issues.

---

![bg right w:90%](../Models/Data/User.png)

#### The `User` entity

The `User` entity represents, as the name suggests, the users of the sample application.

For each user, **a first and a last name** must be defined, which are shown in the GUI.

Furthermore, each user has a unique **identifier** as well as create, update, and delete timestamps.


---

![bg right w:90%](../Models/Data/Issue.png)

#### The `Issue` entity

The `Issue` entity represents problems with some machine reported by the users.

Each issue carries the identifier of the corresponding user as well as a **label** explaning the issue.

Also, each issue has a unique **identifier** as well as a create, update, and delete timestamp.

---

![bg right w:90%](../Models/Data/Comment.png)

#### The `Comment` entity

Finally, the `Comment` entity represents, as the name suggests, comments associated to issues.

For each comment, the identifier of the corresponding user and a **text** is defined.

Moreover, each comment has a unique **identifier** as well as a create, update, and delete timestamp.

---

<!-- _class: center -->

### Component model

**Components** and their **dependencies / interactions**

---

![bg right w:90%](../Models/Package/Full.png)

### Component model overview

The sample application comprises **two library** and **three executable** components.

The **library components** include the `CustomLib` and the `CustomSdk` components.

The **executable components** include the `CustomApi`, the `CustomCli`, and the `CustomApp` components.

---

![bg right w:90%](../Models/Package/Lib.png)

### The `CustomLib` component

The `CustomLib` component contains a common set of **classes and interfaces** for the other components.

Most importantly, it defines the **messages** exchanged between the backend and the frontends.

Furthermore, it defines the **contracts** between backend and frontends in the form of *regular interfaces*.

---

![bg right w:90%](../Models/Package/Api.png)

### The `CustomApi` component

The `CustomApi` component implements the **backend** of the sample application.

The backend is responsible for **managing and serving** the entity instances.

The backend services are exposed as **HTTP REST API** using the Microsoft ASP.NET framework.

---

![bg right w:90%](../Models/Package/Sdk.png)

### The `CustomSdk` component

The `CustomSdk` provides a set of classes for **interacting** with the `CustomApi`backend.

The interaction is realized by means of **HTTP REST API clients** producing and consuming messages.

These clients send **request messages** to the backend and the backend responds with **response messages**.

---

![bg right w:90%](../Models/Package/Cli.png)

### The `CustomCli` component

The `CustomCli` component provides a **command line interface (CLI)** for the backend services.

CLIs represent the simplest form of application and are used, e.g., for **administration tasks**.

The implementation uses the clients of the `CustomSdk` to **access** the backend services.

---

![bg right w:90%](../Models/Package/App.png)

### The `CustomApp` component

The `CustomApp` component provides a **graphical user interface (GUI)** for the sample application.

GUIs typically are shipped to the end **users of an application** and excell over CLIs in terms of usability.

The implementation is based in the **Microsoft MAUI.NET** cross-platform application framework.

---

<!-- _class: center dark -->

## Section 2 - The `CustomLib` component

**Models**, **interfaces**, and **exceptions**

---

<!-- _class: center -->

### HTTP request / response *body models*

**JSON-encoded** data exchange through **message bodies**

---

![bg right w:90%](../Models/Message/Body/Type.png)

#### Generic message body model

The REST API uses request and response **messages** for managing the entities (also called *resources*).

For **each resource** (i.e. user, issue, comment) we distinguish `Read`, `Create`, and `Update` messages.

In the following, we describe each **type of message** in more detail including their data fields.

---

![bg right w:90%](../Models/Message/Body/Update.png)

#### `Update` request body models

The `Update` messages contain the fields that you can **override later** after creating an instance.

For `User` entities, **the first and the last name** can be changed any time later.

For `Issue` entities, the **label** can be changed later, and for `Comment` entities the **text**.

---

![bg right w:90%](../Models/Message/Body/Create.png)

#### `Create` request body models

The `Create` messages derive from the `Update` messages and add the fields that you can **set initially only**.

For `Issue` entities you must define the identifier of the **user** who created the issue.

For `Comment` entities you must define the identifier of the **user** as well as the containing **issue**.

---

![bg right w:90%](../Models/Message/Body/Read.png)

#### `Read` response body models

Finally, the `Read` messages derive from the `Create` messages and add the fields that are **read-only**.

For all entities the read-only fields include the **unique entity identifier** selected randomly on creation.

Furthermore, the read-only fields include **create, update, and delete timestamps** managed automatically.

---

<!-- _class: center -->

### HTTP request *query models*

**URL-encoded** data exchange through **query strings**

---

![bg right w:90%](../Models/Message/Query/Type.png)

#### Generic request query model

In addition to the body models, the HTTP REST API uses so-called **query** models.

The query models define the parameters for **querying and filtering** the resources.

Again, we define **for each resource type** (i.e. user, issue, comment) an independent query model.

---

![bg right w:90%](../Models/Message/Query/Query.png)

#### Concrete request query models

The diagram on the right shows the **query models** for the different entities of the system.

The query models for users and issues **do not provide** any special querying and filtering capabilities.

Only the query model for comments allows to filter the instances by **associated issue identifier**.

---

<!-- _class: center -->

### Abstract interface

**Resource-independent** method signatures

---

![bg right w:90%](../Models/Interface/Overview.png)

#### Abstract interface overview

Based on the previous body and query models we **define the methods** of the REST API.

We use a **generic interface** model including `Find`, `Create`, `Read`, `Update`, and `Delete` methods.

In the following, we explain each method **in more detail** including its inputs and outputs.

---

![bg right w:90%](../Models/Interface/Find.png)

#### The `Find` method

The `Find` method returns a **collection** of created (and *not* deleted) instances.

The method receives parameters for **filtering** through the respective `Query` model.

The method returns a list of the **matching instances** encoded using the respective `Read` model.

---

![bg right w:90%](../Models/Interface/Create.png)

#### The `Create` method

The `Create` method **creates and returns** new instances of a given entity type.

The **input parameters** use the corresponding `Create` model defined previously.

The **return type** corresponds to the respective `Read` model from before.

---

![bg right w:90%](../Models/Interface/Read.png)

#### The `Read` method

The `Read` method **returns** an existing instance with a given identifier.

The **single input parameter** represents the identifier of the desired instance.

The **return type** corresponds to the respective `Read` model from before.

---

![bg right w:90%](../Models/Interface/Update.png)

#### The `Update` method

The `Update` method **overrides and returns** an existing instance with a given identifier.

The **two input parameters** are the identifier of the instance and the respective `Update` model.

The **return type** corresponds to the respective `Read` model as introduced before.

---

![bg right w:90%](../Models/Interface/Delete.png)

#### The `Delete` method

Finally, the `Delete` method **deletes and returns** an existing instance with a given identifier.

The **single input parameter** represents the identifier of the instance that shall be deleted.

The **return type** again corresponds to the `Read` model of the correspnding resource type.

---

<!-- _class: center -->

### Concrete interfaces

**Resource-dependent** method signatures

---

![bg right w:90%](../Models/Interface/User.png)

#### The users interface

The diagram on the ride side shows the **concrete interface** for managing `User` entities.

The type parameters `ResourceRead` and `ResourceQuery` **are replaced** with `UserRead` and `UserQuery`.

Also, `ResourceCreate` and `ResourceUpdate` **are substituted** with `UserCreate` and `UserUpdate`.

---

![bg right w:90%](../Models/Interface/Issue.png)

#### The issues interface

The diagram on the ride side shows the **concrete interface** for managing `Issue` entities.

The type parameters `ResourceRead` and `ResourceQuery` **are replaced** with `IssueRead` and `IssueQuery`.

Also, `ResourceCreate` and `ResourceUpdate` **are substituted** with `IssueCreate` and `IssueUpdate`.

---

![bg right w:90%](../Models/Interface/Comment.png)

#### The comments interface

The diagram on the ride side shows the **concrete interface** for managing `Comment` entities.

The parameters `ResourceRead` and `ResourceQuery` **are replaced** with `CommentRead` and `CommentQuery`.

Also, `ResourceCreate` and `ResourceUpdate` **are substituted** with `CommentCreate` and `CommentUpdate`.

---

<!-- _class: center -->

### Exceptions

**Potential problems** during method execution

---

![bg right w:90%](../Models/Exception/Overview.png)

#### Exception overview

Under some circumstances, the interface methods **cannot** execute successfully.

If such circumstances occur, the methods **throw** one of the exceptions shown on the right side.

In the sample application we distinguish two exception types:  **HTTP** and **parse exceptions**.

---

![bg right w:90%](../Models/Exception/Http.png)

#### HTTP exceptions

HTTP exceptions indicate that the method **could not** be executed successfully.

There are different reasons why **method execution** might not have been successful.

In the HTTP protocol and HTTP REST APIs, the reasons are **differentiated** by means of *status codes*.

---

![bg right w:90%](../Models/Exception/400.png)

#### Bad request exceptions

The first possible reason is called **bad request** and comes with a status code of `400`.

Bad request exceptions indicate an **issue** with the **HTTP request message** sent to the backend.

For example, the request message might **miss mandatory parameters** for method execution.

---

![bg right w:90%](../Models/Exception/401.png)

#### Unauthorized exceptions

The second possible reason is that the caller **has not provided** authorization information.

Typically, backend methods can only be executed by users, which have **registered and signed in**.

If an adequate authorization proof is missing, the backend will answer with **unauthorized status** `401`.

---

![bg right w:90%](../Models/Exception/403.png)

#### Forbidden exceptions

The third possible reason is that the caller has authorized, but does not have the **necessary permissions**.

For example, a registered and signed in user **should not be allowed** to change other user profiles.

If such request is received by the backend, it will answer with the **forbidden status** `403`.

---

![bg right w:90%](../Models/Exception/404.png)

#### Not found exceptions

The fourth possible reason is that the user tries to **access an entity** which does not exist.

For example, the user might want to update an entity which has been **deleted in the meantime**.

In such cases the backend will respond with the **not found status code** `404`.

---

![bg right w:90%](../Models/Exception/Parse.png)

#### Parse exceptions

Even if none of the previous exceptions occur, **another kind** of problem might arise.

In the sample application all interface methods are **expected to consume and produce** JSON encoded data.

If the JSON parser **fails to decode** a message, a parse exception will be thrown.

---

<!-- _class: center dark -->

## Section 3 - The `CustomApi` component

**Managers**,  **controllers**, **handlers**, and the **Swagger UI**

---

<!-- _class: center -->

### Managers

A **simple main-memory storage** for the entities.

---

![bg right h:90%](../Models/Manager/Full.png)

### Manager overview

In the `CustomApi` component, the **managers** are responsible for storing, updating, and querying the entities.

For overall **type safety**, the managers implement the interfaces of the `CustomLib`component.

Furthermore, the manager implementations are based on the **singleton design pattern**.

---

![bg right h:90%](../Models/Manager/Full.png)

### Manager overview (cont'd)

Internally, the managers **maintain their instances** using both a `List` and a `Dictionary` data structure.

The `List` data structure simply stores all instances in a **flat sequence**, which can be iterated easily.

The `Dictionary` data structure instead supports quick access by **instance identifier**.

---

![bg right h:90%](../Models/Manager/User.png)

### The `UsersManager` singleton

The `UsersManager` is responsible for managing the **users** of the sample application.

User **find, create, read, and update operations** are managed completely *internally*.

User **delete operations** are forwarded to the `IssuesManager` and the `CommentsManager` recursively.

---

![bg right h:90%](../Models/Manager/Issue.png)

### The `IssuesManager` singleton

The `IssuesManager` is responsible for managing the **issues** of the sample application.

Issue **find, create, read, and update operations** again are managed completely *internally*.

And issue **delete operations** are forwarded to the `CommentsManager` recursively.

---

![bg right h:90%](../Models/Manager/Comment.png)

### The `CommentsManager` singleton

The `CommentsManager` is responsible for managing the **comments** of the sample application.

Comment **find, create, read, and update operations** again are managed completely *internally*.

Also comment **delete operations** *must not be forwarded* recursively and can be managed internally.

---

<!-- _class: center -->

### Controllers

*Coming soon*

---

### Controller overview

*Coming soon*

---

<!-- _class: center -->

### Handlers

*Coming soon*

---

### Handler overview

*Coming soon*

---

<!-- _class: center -->

### Swagger UI

*Coming soon*

---

![bg right h:90%](../Screenshots/CustomApi.png)

### Swagger UI overview

The data itself is managed by an **ASP.NET backend** service with standard REST API.

The screenshot on the right provides an **overview** of the API services exposed.

For each **resource** (i.e. user, issue, comment), the same set of functions is defined.

---

<!-- _class: center dark -->

## Section 4 - The `CustomSdk` component

*Coming soon*

---

### Software development kit (SDK)

*Coming soon*

---

<!-- _class: center dark -->

## Section 5 - The `CustomCli` component

*Coming soon*

---

### Command line interface (CLI)

*Coming soon*

---

<!-- _class: center dark -->

## Section 6 - The `CustomApp` component

**MAUI.NET frontend**, **view models**, and **pages**

---

![bg right w:90%](../Screenshots/CustomApp-Users.png)

### MAUI.NET frontend

The C# MAUI.NET / ASP.NET Sample Application features a **basic** graphical user interface (GUI).

With the GUI you can manage the **users** and the **issues** stored in the underlying database.

The screenshot on the right shows the **users page** listing all created user entities.

---

![bg right w:90%](../Screenshots/CustomApp-User.png)

### MAUI.NET frontend (cont'd)

When clicking an existing user or creating a new user, you enter the **user detail** page.

The user detail page shows all the **data associated** with a user entity in the database.

You can change the **first and last name**, the other fields are set automatically.

---

<!-- _class: center -->

### View models

*Coming soon*

---

![bg right w:90%](../Models/Pages.png)

### View model overview

*Coming soon*

---

<!-- _class: center -->

### Pages

*Coming soon*

---

![bg right w:90%](../Models/Pages.png)

### Page overview

*Coming soon*

---

<!-- _class: center dark -->

## Section 7 - The follow-up resources

*Coming soon*

---

### Follow-up resource overview

*Coming soon*

---

<!-- _class: center dark -->

## You are ready to code 👩‍💻

Well done!