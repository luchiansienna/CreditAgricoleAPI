
# Credit Agricole Price listing app

This is a Web Api application that display a list of products and price updates and is developed using C# .NET Core framework.

## Main functionality

The app displays a list of prices on the interface being updated every second with new prices.

There are 2 endpoints in place: 

* **/api/productlist** : API endpoint that returns the list of the products without prices, just ID and name


* **/ws/productprices** : For the Price List every second updates I have used a WebSocket returning an array with ProductID, Price and UpdatedAt.
  
I have used UpdatedAt field part of the price list entity with the purpose of displaying a precise time to that specific price.
The price is being generated in the back end service, it could be at different times (in the interval of one second) than the other prices.

I have used a WebSocket because compared to the HTTP protocol, WebSocket eliminates the need for a new connection with every request, reducing the size of each message (no HTTP headers).


## Steps to set the app on your local machine

1. **Install .Net Framework Core on your machine

2. Run your app locally on IIS Express or any other .NET web server

The Swagger start up page will help in calling the Product List API.

Hitting GET on the /api/productlist endpoint will return the list of products with ID and name, 10 hardcoded products.
This is located in ProductListService.

The second enpoint is the price list websocket /ws/productprices , which returns the price list array every second. The prices are generated randomly, a number between 1 and 100.


## Projects

**CreditAgricole.Domain** - contains the models of the domain

**CreditAgricole.Services** - contains 2 main services : ProductPrices and ProductList

**CreditAgricole.WebSocketService** - an implementation of the websocket wrapper that sends the product prices every second. 
I am using the System.Net.WebSockets library to create the websocket connection, Dispose method and a cancellationToken to securily stop and clean the connection.

**CreditAgricole.Web** - the web app that serve these 2 controllers: ProductListController and WebSocketController


SOLID principles are applied, along with KISS and DRY.

## Improvements that can be added are : 

* The use of DTOs with Automapper
* SQL Database with the product list and an the use of an ORM like EF Core
* The use of SignalR wrapper over the WebSockets
* A caching mechanism in place where the data is not changed often, like the product list
* Unit tests and e2e tests
* Authentication & Authorization

## Data Models

* **Product** - the product : ID and name
* **ProductPrice** - the product price: ProductID, Price and UpdatedAt

## Unit tests

All services are testable because they are implemented with no concrete dependencies ( dependecy injection applied ).
WebSocket can be mocked and passed into the constructor of WebSocketWrapper.

* **CreditAgricole.Services.Tests** - 
* **CreditAgricole.WebSocketService.Tests** -

## CORS policy is activated
CORS policy is activated for ports 3000 and 3001, multiple can be added if needed at CreditAgricole.Web\WebConfiguration.cs
