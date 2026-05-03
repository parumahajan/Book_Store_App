This repository contains the files for "Book-Store Application".

I have made it using Webforms in .NET, and Entity Framework.
For the Database, I have used "MS SQL Server".

I have implemented these 7 features within my application:
1) User Login
2) Registration
3) Show Books
4) Add to Cart
5) Add to Wishlist
6) Place Order
7) Order History


# Database Design
![WhatsApp Image 2025-12-29 at 10 50 45 AM](https://github.com/user-attachments/assets/45678918-bce0-4dc4-b29f-0769daada6e3)

## Directory structure:
```
└── parumahajan-book_store_app/
    ├── README.md
    ├── Bookstore.slnx
    └── Bookstore/
        ├── About.aspx
        ├── About.aspx.cs
        ├── About.aspx.designer.cs
        ├── AdminBooks.aspx
        ├── AdminBooks.aspx.cs
        ├── AdminBooks.aspx.designer.cs
        ├── Book.cs
        ├── Bookstore.csproj
        ├── Bundle.config
        ├── Cart.aspx
        ├── Cart.aspx.cs
        ├── Cart.aspx.designer.cs
        ├── Cart.cs
        ├── Checkout.aspx
        ├── Checkout.aspx.cs
        ├── Checkout.aspx.designer.cs
        ├── Default.aspx
        ├── Default.aspx.cs
        ├── Default.aspx.designer.cs
        ├── Global.asax
        ├── Global.asax.cs
        ├── JwtHelper.cs
        ├── Login.aspx
        ├── Login.aspx.cs
        ├── Login.aspx.designer.cs
        ├── Order.cs
        ├── OrderDetails.aspx
        ├── OrderDetails.aspx.cs
        ├── OrderDetails.aspx.designer.cs
        ├── OrderItem.cs
        ├── Orders.aspx
        ├── Orders.aspx.cs
        ├── Orders.aspx.designer.cs
        ├── OurBookStore.Context.cs
        ├── OurBookStore.Context.tt
        ├── OurBookStore.cs
        ├── OurBookStore.Designer.cs
        ├── OurBookStore.edmx
        ├── OurBookStore.edmx.diagram
        ├── OurBookStore.tt
        ├── packages.config
        ├── Question.txt
        ├── Registration.aspx
        ├── Registration.aspx.cs
        ├── Registration.aspx.designer.cs
        ├── ShowBooks.aspx
        ├── ShowBooks.aspx.cs
        ├── ShowBooks.aspx.designer.cs
        ├── Site.Master
        ├── Site.Master.cs
        ├── Site.Master.designer.cs
        ├── Site.Mobile.Master
        ├── Site.Mobile.Master.cs
        ├── Site.Mobile.Master.designer.cs
        ├── UserInfo.cs
        ├── ViewSwitcher.ascx
        ├── ViewSwitcher.ascx.cs
        ├── ViewSwitcher.ascx.designer.cs
        ├── Web.config
        ├── Web.Debug.config
        ├── Web.Release.config
        ├── Webform.aspx
        ├── Webform.aspx.cs
        ├── Webform.aspx.designer.cs
        ├── Wishlist.aspx
        ├── Wishlist.aspx.cs
        ├── Wishlist.aspx.designer.cs
        ├── Wishlist.cs
        ├── App_Start/
        │   ├── BundleConfig.cs
        │   └── RouteConfig.cs
        ├── Content/
        │   ├── bootstrap-reboot.css
        │   ├── bootstrap-reboot.rtl.css
        │   └── Site.css
        ├── CSS/
        │   ├── adminbooks.css
        │   ├── cart.css
        │   ├── checkout.css
        │   ├── default.css
        │   ├── login.css
        │   ├── orders.css
        │   ├── registration.css
        │   ├── showbooks.css
        │   └── wishlist.css
        ├── Properties/
        │   └── AssemblyInfo.cs
        └── Scripts/
            └── WebForms/
                ├── DetailsView.js
                ├── Focus.js
                ├── GridView.js
                ├── Menu.js
                ├── MenuStandards.js
                ├── SmartNav.js
                ├── TreeView.js
                ├── WebForms.js
                ├── WebParts.js
                ├── WebUIValidation.js
                └── MSAjax/
                    ├── MicrosoftAjaxApplicationServices.js
                    ├── MicrosoftAjaxComponentModel.js
                    ├── MicrosoftAjaxCore.js
                    ├── MicrosoftAjaxGlobalization.js
                    ├── MicrosoftAjaxHistory.js
                    ├── MicrosoftAjaxNetwork.js
                    ├── MicrosoftAjaxSerialization.js
                    ├── MicrosoftAjaxTimer.js
                    ├── MicrosoftAjaxWebForms.js
                    └── MicrosoftAjaxWebServices.js
```
