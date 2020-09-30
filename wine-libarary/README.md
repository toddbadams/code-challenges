

## Wine Entries [/wineentries]
 
### Create [POST]
+ Request 
  + **WineEntryRequest**
+ Response 204 
 
### List all [GET]
+ Response 200 
  + array[**WineEntry**]
  
## Cellars [/cellars]
 
### Create [POST]
+ Request 
  + **CellarRequest**
+ Response 204 
 
### List all [GET]
+ Response 200 
  + array[**Cellar**]

### WineEntryRequest
+ action: add (string) - add, sell, gift, lost, broken, consume, other
+ vintage: 1982 (number) - year of harvest
+ BottleSize: 750 (**BottleSize**) 
+ DutyStatus: IB (**DutyStatus**) 
+ packSize: 6 (**PackSize**) 
+ cellar: Home (**Cellar**) 
+ wine: (**Wine**) 
  
### WineEntry
+ vintage: 1982 (number) - year of harvest
+ BottleSize: 750 (number) - size of bottle in milliliters
+ DutyStatus: IB (**DutyStatus**) 
+ packSize: 6 (number) - the number of bottles in the package
+ cellar: Home (**Cellar**) 
+ wine: (**Wine**) 

### Wine 
+ title: Domaine Leroy Musigny Grand Cru, Chambolle-Musigny, Cote de Nuits, Burgundy, France Red (string) - producer + name + location + type  a unique title
+ name: (string) - Musigny Grand Cru
+ location: Musigny Grand Cru, Chambolle-Musigny, Cote de Nuits, Burgundy, France (string) - location hierarchy
+ producer: Domaine Leroy (string) - name of producer
+ type: Red (**WineType**) 

### Cellar 
+ title: Home (string) - a unique name for the cellar
+ accountRef: ADAT123 (string) - a unique account reference for the cellar
  
### CellarRequest
+ action: add (string) - add, close
+ title: Home (string) - a unique name for the cellar
+ accountRef: ADAT123 (string) - a unique account reference for the cellar

## Enumerations [/enumerations]
 
### List all [GET]
+ Response 200 
    + array[EnumerationSet]

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


