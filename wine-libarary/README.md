
# Cellars [/cellars]
 
### Create [POST]
+ Request 
  + headers
    + Authorization: Bearer xyz... (**User JWT**)
  + body
    + **Cellar**
+ Response 204  

### Update [PUT]
+ Request 
  + headers
    + Authorization: Bearer xyz... (**User JWT**)
    + WWW-Authorization: Bearer abc... (**Cellar Resource JWT**)
  + body
    + **CellarUpdate**
+ Response 204 
 
### List all [GET]
+ Response 200 
  + array[**CellarResponse**]

### CellarUpdate : Cellar
+ action: (**CellarAction**) 

### CellarResponse
+ authorization: abc... (**Cellar Resource JWT**) - used to gain access to the cellar resource

### Cellar Resource JWT
The response is a JWT representing cellar claims.
 
+ header
  + alg: HS256 (string) - the signing algorithm being used, which is HS256
  + typ: JWT (string) - the type of the token, which is JWT

+ payload
  + sub: ADAT001 (string) - globally unique identifier for the claim principal.
  + exp: 1601460689 (number) - identifies the expiration time on or after which the JWT MUST NOT be accepted for processing.
  + jti: ba9a1fe80d6742b28b76a091fdf23ce4 (string) - provides a unique identifier for the JWT.
  + cellar: (**Cellar**)
  + actions: update, close (string) - list of permitted cellar actions

### Cellar 
+ title: Home (string) - a unique (url safe) name for the cellar
+ accountRef: ADAT123 (string) - a unique account reference for the cellar

### CellarAction 
+ title: close (string) - the action to apply to a cellar entry: update, close



# Wine Entries [/cellars/{title}/wineentries]
 
### Create [POST]
+ Request 
  + headers
    + Authorization: Bearer xyz... (**User JWT**)
  + body
    + **WineEntry**
+ Response 204 
  
### Sell [PUT /cellars/{title}/wineentries.sell]
+ Request 
  + headers
    + Authorization: Bearer xyz... (**User JWT**)
    + WWW-Authorization: Bearer abc... (**Wine Entry Resource JWT**)
  + body
    + packQuantity: 1 (number) - the number of packages
    + price: 109.90 (number) - the selling price of each package
+ Response 204 

  
### Dispose [PUT /cellars/{title}/wineentries.dispose]
+ Request 
  + headers
    + Authorization: Bearer xyz... (**User JWT**)
    + WWW-Authorization: Bearer abc... (**Wine Entry Resource JWT**)
  + body
    + packQuantity: 1 (number) - the number of packages
    + reason: drank with friends (string) - reason to dispose
+ Response 204 

### Move to another cellar [PUT /cellars/{title}/wineentries.move]
+ Request 
  + headers
    + Authorization: Bearer xyz... (**User JWT**)
    + WWW-Authorization: Bearer abc... (**Wine Entry Resource JWT**)
  + body
    + fromPackQuantity: 1 (number) - the number of packages of the from cellar
    + reason: bringing home (string) - reason to move
    + dutyPaid:  23.50 (number) - the amount of duty paid 
    + Vat: 200.00 (number) - the amount of Vat paid
    + packSize: 6 (number) - the number of bottles in the package of new cellar
    + packQuantity: 1 (number) - the number of packages in the new cellar, total bottle count must equal moved quantity
+ Response 204 
 
### List all [GET]
+ Request 
  + headers
    + Authorization: Bearer xyz... (**User JWT**)
+ Response 200 
  + body
    + array[**WineEntryResponse**]
  
### WineEntryResponse
+ wineEntry: abc... (**WineEntry Resource JWT**) - used to gain access to the wine entry resource
  
### WineEntry
+ vintage: 1982 (number) - year of harvest
+ bottleSize: 750 (number) - size of bottle in milliliters
+ dutyStatus: IB (**string**) - DP, IB
+ packSize: 6 (number) - the number of bottles in the package
+ packQuantity: 1 (number) - the number of packages
+ cellar: Home (**Cellar**) 
+ wine: (**Wine**) 

### Wine 
+ title: Domaine Leroy Musigny Grand Cru, Chambolle-Musigny, Cote de Nuits, Burgundy, France Red (string) - producer + name + location + type  a unique title
+ name: (string) - Musigny Grand Cru
+ location: Musigny Grand Cru, Chambolle-Musigny, Cote de Nuits, Burgundy, France (string) - location hierarchy
+ producer: Domaine Leroy (string) - name of producer
+ type: red (string) - red, white, sparking, orange, sweet

### Wine Entry Resource JWT
The response is a JWT representing cellar claims.
 
+ header
  + alg: HS256 (string) - the signing algorithm being used, which is HS256
  + typ: JWT (string) - the type of the token, which is JWT

+ payload
  + sub: ADAT001 (string) - globally unique identifier for the claim principal.
  + exp: 1601460689 (number) - identifies the expiration time on or after which the JWT MUST NOT be accepted for processing.
  + jti: ba9a1fe80d6742b28b76a091fdf23ce4 (string) - provides a unique identifier for the JWT.
  + wineEntry: (**WineEntry**)
  + actions: sell, dispose, move (string) - list of permitted wine entry actions


# User JWT
A compact, URL-safe means of representing claims to be transferred between two parties.
 
### header
+ alg: HS256 (string) - the signing algorithm being used, which is HS256
+ typ: JWT (string) - the type of the token, which is JWT

## payload
+ sub: ADAT001 (string) - globally unique identifier for the claim principal.
+ exp: 1601460689 (number) - identifies the expiration time on or after which the JWT MUST NOT be accepted for processing.
+ jti: ba9a1fe80d6742b28b76a091fdf23ce4 (string) - provides a unique identifier for the JWT.
