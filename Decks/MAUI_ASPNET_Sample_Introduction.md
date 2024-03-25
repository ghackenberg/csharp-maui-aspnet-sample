---
marp: true
theme: CustomTheme
header: C# MAUI.NET / ASP.NET Sample Application
footer: Dr. Georg Hackenberg | Professor for Industrial Informatics | FH OÖ
paginate: true
---

<!-- _class: clean center -->

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

![bg right:40% w:100%](../Images/MAUI_ASPNET_Sample_Social_Preview_Image.png)

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

The `CustomLib` contains a common set of **classes and interfaces** used by the other components.

Most importantly, the `CustomLib` defines the **messages** exchanged between backend and frontends.

Furthermore, the `CustomLib` defines the **contracts** between backend and frontends as *regular interfaces*.

---

![bg right w:90%](../Models/Package/Api.png)

### The `CustomApi` component

*Coming soon*

---

![bg right w:90%](../Models/Package/Sdk.png)

### The `CustomSdk` component

*Coming soon*

---

![bg right w:90%](../Models/Package/Cli.png)

### The `CustomCli` component

*Coming soon*

---

![bg right w:90%](../Models/Package/App.png)

### The `CustomApp` component

*Coming soon*

---

<!-- _class: center dark -->

## Section 2 - The `CustomLib` component

**Messages**, **exceptions**, and **interfaces**

---

<!-- _class: center -->

### Messages

**Data exchange** between frontend and backend

---

![bg right w:90%](../Models/Message/Type.png)

#### Message overview

The REST API uses request and response **messages** for working with these entities.

For **each resource** (i.e. user, issue, comment) we distinguish `Get`, `Post`, and `Put` messages.

In the following, we describe each **type of message** in more detail including their data fields.

---

![bg right w:90%](../Models/Message/Put.png)

#### `Put` messages

The `Put` messages contain the fields that you can **override later** after creating an instance.

For `User` entities, **the first and the last name** can be changed any time later.

For `Issue` entities, the **label** can be changed later, and for `Comment` entities the **text**.

---

![bg right w:90%](../Models/Message/Post.png)

#### `Post` messages

The `Post` messages derive from the `Put` messages and add the fields that you can **set initially only**.

For `Issue` entities you must define the identifier of the **user** who created the issue.

For `Comment` entities you must define the identifier of the **user** as well as the containing **issue**.

---

![bg right w:90%](../Models/Message/Get.png)

#### `Get` messages

Finally, the `Get` messages derive from the `Post` messages and add the fields that are **read-only**.

For all entities the read-only fields include the **unique entity identifier** selected randomly on creation.

Furthermore, the read-only fields include **create, update, and delete timestamps** managed automatically.

---

<!-- _class: center -->

### Exceptions

**Problems** during service execution

---

![bg right w:90%](../Models/Exceptions.png)

#### Exception overview

*Coming soon*

---

<!-- _class: center -->

### Interfaces

**Methods** *provided by* backend and *required by* frontend

---

![bg right w:90%](../Models/Interface.png)

#### Interface overview

Based on the message data structures we **define the methods** of the REST API.

We use a **generic interface** model including `List`, `Post`, `Get`, `Put`, and `Delete` methods.

In the following, we explain each method **in more detail** including inputs and outputs.

---

![bg right w:90%](../Models/Interface.png)

#### The `List` method

The `List` method returns a **collection** of created (and *not* deleted) instances.

Note that in our case the method **does not require** any input parameters.

*Usually the input parameters are used for **filtering and paging** the instances.*

---

![bg right w:90%](../Models/Interface.png)

#### The `Post` method

The `Post` method **creates and returns** new instances of a given entity type.

The **input parameters** use the corresponding `Post` message defined previously.

The **return type** corresponds to the respective `Get` message from before.

---

![bg right w:90%](../Models/Interface.png)

#### The `Get` method

The `Get` method **returns** an existing instance with a given identifier.

The **single input parameter** represents the identifier of the desired instance.

The **return type** corresponds to the respective `Get` message from before.

---

![bg right w:90%](../Models/Interface.png)

#### The `Put` method

The `Put` method **overrides and returns** an existing instance with a given identifier.

The **two input parameters** are the identifier of the instance and the respective `Put` message.

The **return type** corresponds to the respective `Get` type as introduced before.

---

![bg right w:90%](../Models/Interface.png)

#### The `Delete` method

Finally, the `Delete` method **deletes and returns** an existing instance with a given identifier.

Note that deleting an instance **does not remove** the dataset from the database.

Instead, the `DeletedAt` timestamp of the instance is **set to the current timestamp**.

---

<!-- _class: center dark -->

## Section 3 - The `CustomApi` component

**ASP.NET backend** and **controllers**

---

![bg right h:90%](../Screenshots/CustomApi.png)

### ASP.NET backend

The data itself is managed by an **ASP.NET backend** service with standard REST API.

The screenshot on the right provides an **overview** of the API services exposed.

For each **resource** (i.e. user, issue, comment), the same set of functions is defined.

---

<!-- _class: center -->

### Controllers

*Coming soon*

---

### Controller overview

*Coming soon*

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