---
marp: true
theme: CustomTheme
header: Short introduction to the C# MAUI.NET / ASP.NET Sample Application
footer: Dr. Georg Hackenberg | Professor for Industrial Informatics | FH OÖ
paginate: true
---

<!-- _class: clean center -->

# Short introduction to the<br/>C# MAUI.NET / ASP.NET Sample Application

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

## Section overview


- **Section 1 - Basics** you should know before diving deeper
- **Section 2 - The `CustomLib` project** containing common classes
- **Section 3 - The `CustomApi` project** implementing the backend
- **Section 4 - The `CustomApp` project** implementing the frontend

---

<!-- _class: center dark -->

## Section 1 - Basics

**Domain model** and **package structure**

---

![bg right w:90%](../Models/Data.svg)

### The domain model

The diagram on the right shows the **domain model** implemented by the application.

The data model consists of **three entities**, namely `User`, `Issue`, and `Comment`.

Issues and comments are `created by` users, comments are `contained in` issues.

---

![bg right w:90%](../Models/Package.svg)

### The project structure

The sample application comprises **three code projects**: `CustomLib`, `CustomApi`, and `CustomApp`.

The `CustomLib` provides a common **class library** used by the other two projects.

The `CustomApi` implements the **backend**, the `CustomApp` the **frontend**.

---

<!-- _class: center dark -->

## Section 2 - The `CustomLib` project

**Message** and **interface structures**

---

<!-- _class: center -->

### Message structures

**Data exchange** between frontend and backend

---

![bg right w:90%](../Models/Message.svg)

#### Message structures

The REST API uses corresponding **data structures** for working with these entities.

For **each resource** (i.e. user, issue, comment) we distinguish `Get`, `Post`, and `Put` data structures.

The `Put` structures contain the fields that you can **override later** after creating an instance.

---

![bg right w:90%](../Models/Message.svg)

#### `Post` and `Get` structures

The `Post` structures derive from the `Put` structures and add the fields that you can **set only initially** when creating an instance such as entity references.

Finally, the `Get` structures derive from the `Post` structures and add the fields that are **read only** such as instance identifiers and timestamps.

---

<!-- _class: center -->

### Interface structures

Methods **provided by** backend and **required by** frontend

---

![bg right w:90%](../Models/Interface.svg)

#### Interface structures

Based on the message data structures we **define the methods** of the REST API.

We use a **generic interface** model including `List`, `Post`, `Get`, `Put`, and `Delete` methods.

The `List` method returns a **collection** of created (and *not* deleted) instances.

---

![bg right w:90%](../Models/Interface.svg)

#### `Post`, `Get`, and `Put` methods

The `Post` method **creates and returns** new instances of a given entity type.

The `Get` method **returns** an existing instance with a given identifier.

The `Put` method **overrides and returns** an existing instance with a given identifier.

---

![bg right w:90%](../Models/Interface.svg)

#### The `Delete` method

Finally, the `Delete` method **deletes and returns** an existing instance with a given identifier.

Note that deleting an instance **does not remove** the dataset from the database.

Instead, the `DeletedAt` timestamp of the instance is **set to the current timestamp**.

---

<!-- _class: center dark -->

## Section 3 - The `CustomApi` project

**ASP.NET backend** and **controller structures**

---

![bg right h:90%](../Screenshots/CustomApi.png)

### ASP.NET backend

The data itself is managed by an **ASP.NET backend** service with standard REST API.

The screenshot on the right provides an **overview** of the API services exposed.

For each **resource** (i.e. user, issue, comment), the same set of functions is defined.

---

### Controller structures

*Coming soon*

---

<!-- _class: center dark -->

## Section 4 - The `CustomApp` project

**MAUI.NET frontend** and **page structures**

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

![bg right w:90%](../Models/Pages.svg)

### Page structures

*Coming soon*

---

<!-- _class: center dark -->

## You are ready to start coding 👩‍💻

Well done!