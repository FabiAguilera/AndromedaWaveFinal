"# AndromedaWaveFinal" 
<div id="top"></div>




<!-- PROJECT SHIELDS -->
<!--
-->






<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">Mission Statement</a>
      <ul>
        <li><a href="#built-with">Database</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Features</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Trello Link</a></li>
      </ul>
    </li>
    <li><a href="#usage">Schedule</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Final Notes</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>



<!-- Mission Statement -->
## Mission Statement

Ride the Andromeda Wave: event search API that brings energy and liveliness to entertainment lovers with ease.

<p align="right">(<a href="#top">back to top</a>)</p>



### Database

* Attendee Table
Table attendee as U {
  attendee_id int [pk, increment] // auto-increment
  full_name string
  created_at datetime
transactionID int
}
Associated with:Transactions
Group member assigned to this table: Collin

*Transaction Table
Table transactions {
  transactions_id int [pk] // primary key
  status bool
  created_at datetime [note: 'When order created'] // add column note
merchantId foreignkey
ICollection<Attendee> Attendee
Public virtual  ICollection<Product> Products {get; set;} = new List<Product>();
}
Associated with: Attendee, Products, Merchants
Group member assigned to this table: Collin

*Venue Table
Table venue {
  venue_id int [pk]
  address string
  description string
Public virtual  ICollection<Product> Products {get; set;} = new List<Product>();
}
Associated with: Products
Group member assigned to this table: Andrew
  
*Category Table
Table category {
  category_id int [pk]
  categorytype string
Public virtual  ICollection<Product> Products {get; set;} = new List<Product>();
 }
Associated with: Products
Group member assigned to this table: Andrew
  
*Product Table

This is where your team writes out how your database will look like. List out each table, the columns (include the dataTypes), and the database associations your project will have on the server-side.
Table products {
  ticket_id int [pk]
  eventname string
  merchant_id int [not null]
  ticketprice int
  statusofticket string
  created_at datetime [default: `now()`]
admission string
TransactionId
CategoryId
VenueId
MerchantId
  }
Associated with: Categories, Venue, Transactions, Merchants
Group member assigned to this table: Fabiola

*Merchant Table
Table merchants {
  merchant_id int [pk]
  address string
  merchant_name string
  created_at datetime
Public virtual  ICollection<Product> Products {get; set;} = new List<Product>();
Public virtual  ICollection<Transactions> Transactions{get; set;} = new List<Transaction>();
  }
Associated with: Products
Group member assigned to this table: Fabiola

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- Diagram -->
## Diagram

Click on the following link to view the diagram, or simply look below for a quick view!
  
  <img src="https://dbdiagram.io/embed/61fb09b885022f4ee52e0b14" alt="AndromedaDBDiagram">

### Features

The following are features of Version 1.0 of Andromeda Wave: 
*Attendee Registration
*Product Availability
*Event Categories
*Merchant (Sellers) List
*Venue List
*Transactions of Attendees
 
The following are features of Version 2.0 of Andromeda Wave:
*Implementing 3rd party API of local venues
*FAQs
*Discounted/Free Events
*Package Deals(Hotel/Stay)
*FrontEnd API


### EndPoints

1. Attendee
  *HTTP Method
  *CRUD
  *POST
  *Create the attendee 
  *GET
  *Read list of attendees or single attendee
  *Delete
  *Delete attendee’s account




<!-- ACKNOWLEDGMENTS -->
## Acknowledgments

* Thank you to Collin and Andrew for the wonderful work they did in Andromeda Wave! We all helped each other with everything and solved many things together as a team.






