# CustomerPhone RESTful API 

RESTful API using Microsoft .NET Core 2.0
Implemented With C# in  Visual Studio 2017 environment.

## Installation

1.  Clone or download.
2.  Open WebApplication1.csproj file with visual studio 2017.
3.  Run 


## Available end-points

### GET /customers

Gets all the available customers (4 sample ).

### GET /customers/byname/:customername

Obtains an event given  custumer related phone numbers.

### GET /phones

Gets all customer phone numbers.

### GET /activate/:phonenumber

activate(set true) related phone number.

### POST /customers

Creates a local list of customers and their numbers (be sure you are sending the headers via your library).

**Headers**

Content-Type : application/json

**Request body (raw)/customers**

```http://..../api/customers
    [
    {
        "Name": "paul",
        "CusPhoneNumbers": [
            {
                "Number": "11111",
                "Active": false
            },
            {
                "Number": "22222",
                "Active": false
            }
        ]
    },
    {
        "Name": "pitter",
        "CusPhoneNumbers": [
            {
                "Number": "33333",
                "Active": false
            }
        ]
    },
    {
        "Name": "johne",
        "CusPhoneNumbers": [
            {
                "Number": "44444",
                "Active": false
            },
            {
                "Number": "55555",
                "Active": false
            }
        ]
    },
    {
        "Name": "sam",
        "CusPhoneNumbers": [
            {
                "Number": "66666",
                "Active": false
            }
        ]
    }
]
```

**Request body (raw)/customers/byname/johen**

```http://..../api/customers/byname/johne
[
    {
        "number": "44444",
        "active": false
    },
    {
        "number": "55555",
        "active": false
    }
]
```

**Request body (raw)/phones**

```http://..../api/phones
[
    "11111",
    "22222",
    "33333",
    "44444",
    "55555",
    "66666"
]
```
