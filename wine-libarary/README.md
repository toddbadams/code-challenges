
# API

## Wine Entries [/wineentries]
 
### Create [POST]
+ Request 
  + headers
    + Authorization: Bearer xyz... (User JWT)
    + WWW-Authorization: Bearer abc... (Resource JWT)
  + body
    + **WineEntryRequest**
+ Response 204 
 
### List all [GET]
+ Response 200 
  + body
    + array[**WineEntryResponse**]
  
## Cellars [/cellars]
 
### Create [POST]
+ Request 
  + headers
    + Authorization: Bearer xyz... (User JWT)
    + WWW-Authorization: Bearer abc... (Resource JWT)
  + body
    + **CellarRequest**
+ Response 204 
 
### List all [GET]
+ Response 200 
  + array[**CellarResponse**]

### WineEntryRequest
+ action: add (**WineEntryAction**) 
+ vintage: 1982 (number) - year of harvest
+ BottleSize: 750 (**BottleSize**) 
+ DutyStatus: IB (**DutyStatus**) 
+ packSize: 6 (**PackSize**) 
+ cellar: Home (**Cellar**) 
+ wine: (**Wine**) 

### WineEntryResponse
+ authorization: abc... (**WineEntry Resource JWT**) - used to gain access to the wine entry resource
  
### WineEntry
+ vintage: 1982 (number) - year of harvest
+ bottleSize: 750 (number) - size of bottle in milliliters
+ dutyStatus: IB (**DutyStatus**) 
+ packSize: 6 (number) - the number of bottles in the package
+ cellar: Home (**Cellar**) 
+ wine: (**Wine**) 

### Wine 
+ title: Domaine Leroy Musigny Grand Cru, Chambolle-Musigny, Cote de Nuits, Burgundy, France Red (string) - producer + name + location + type  a unique title
+ name: (string) - Musigny Grand Cru
+ location: Musigny Grand Cru, Chambolle-Musigny, Cote de Nuits, Burgundy, France (string) - location hierarchy
+ producer: Domaine Leroy (string) - name of producer
+ type: Red (**WineType**) 

  
### CellarRequest
+ action: add (**CellarAction**) 
+ title: Home (string) - a unique name for the cellar
+ accountRef: ADAT123 (string) - a unique account reference for the cellar 


### CellarResponse
+ authorization: abc... (**Cellar Resource JWT**) - used to gain access to the cellar resource

The response is a JWT representing cellar claims.
 
#### header
+ alg: HS256 (string) - the signing algorithm being used, which is HS256
+ typ: JWT (string) - the type of the token, which is JWT

### payload
+ sub: ADAT001 (string) - globally unique identifier for the claim principal.
+ exp: 1601460689 (number) - identifies the expiration time on or after which the JWT MUST NOT be accepted for processing.
+ jti: ba9a1fe80d6742b28b76a091fdf23ce4 (string) - provides a unique identifier for the JWT.
+ cellar: (**Cellar**)

### Cellar 
+ title: Home (string) - a unique name for the cellar
+ accountRef: ADAT123 (string) - a unique account reference for the cellar
+ authorization: abc... (**Resource JWT**) - used to gain access to the cellar resource

## Enumerations [/enumerations]
 
### List all [GET]
+ Response 200 
    + array[**EnumerationSet**]

### EnumerationSet
+ dutyStatus: array[**DutyStatus**], fixed-type
+ wineType: array[**WineType**], fixed-type
+ wineEntryAction: array[**WineEntryAction**], fixed-type

### DutyStatus 
+ title: Duty Paid (string) - title of the duty status: DP, IB

### WineType 
+ title: Red (string) - title of the wine type: red, white, sparking, orange, sweet

### WineEntryAction 
+ title: add (string) - the action to apply to a wine entry: add, sell, gift, lost, broken, consume, other

### CellarAction 
+ title: add (string) - the action to apply to a cellar entry: add, close


# User JWT
A compact, URL-safe means of representing claims to be transferred between two parties.
 
### header
+ alg: HS256 (string) - the signing algorithm being used, which is HS256
+ typ: JWT (string) - the type of the token, which is JWT

## payload
+ sub: ADAT001 (string) - globally unique identifier for the claim principal.
+ exp: 1601460689 (number) - identifies the expiration time on or after which the JWT MUST NOT be accepted for processing.
+ jti: ba9a1fe80d6742b28b76a091fdf23ce4 (string) - provides a unique identifier for the JWT.
  
# Resource JWT
A compact, URL-safe means of representing claims to be transferred between two parties.
 
### header
+ alg: HS256 (string) - the signing algorithm being used, which is HS256
+ typ: JWT (string) - the type of the token, which is JWT

## payload
+ sub: ADAT001 (string) - globally unique identifier for the claim principal.
+ exp: 1601460689 (number) - identifies the expiration time on or after which the JWT MUST NOT be accepted for processing.
+ jti: ba9a1fe80d6742b28b76a091fdf23ce4 (string) - provides a unique identifier for the JWT.