

## Wine Entries [/wineentries]
 
### Create [POST]
+ Request (application/json)
  + Attributes (WineEntryRequest)
+ Response 204 (application/json)
    + Attributes (array[WineEntry])
 
### List all [GET]
+ Response 200 (application/json)
    + Attributes (array[WineEntry])

### WineEntryRequest
+ Attributes
    + action: add (string) - add, sell, gift, lost, broken, consume, other
    + vintage: 1982 (number) - year of harvest
    + BottleSize: 750 (BottleSize) 
    + DutyStatus: IB (DutyStatus) 
    + packSize: 6 (PackSize) 
    + cellar: Home (Cellar) 
    + wine: (Wine) 
  
### WineEntry
+ Attributes
    + id: 375 (number) - id entry
    + vintage: 1982 (number) - year of harvest
    + BottleSize: 750 (BottleSize) 
    + DutyStatus: IB (DutyStatus) 
    + packSize: 6 (PackSize) 
    + cellar: Home (Cellar) 
    + wine: (Wine) 

### Wine 
+ Attributes
    + id: Domaine Leroy Musigny Grand Cru, Chambolle-Musigny, Cote de Nuits, Burgundy, France Red (string) - producer + name + location + type
    + name: (string) - Musigny Grand Cru
    + location: Musigny Grand Cru, Chambolle-Musigny, Cote de Nuits, Burgundy, France (string) - location hierarchy
    + producer: Domaine Leroy (string) - name of producer
    + type: Red (WineType) 

### Cellar 
+ Attributes
    + id: Home (string) - a unique name for the cellar
    + accountRef: ADAT123 (string) - a unique account reference for the cellar

## Enumerations [/enumerations]
 
### List all [GET]
+ Response 200 (application/json)
    + Attributes (array[EnumerationSet], fixed-type)

### EnumerationSet
+ Attributes
    + bottleSize: array[BottleSize], fixed-type
    + dutyStatus: array[DutyStatus], fixed-type
    + packSize: array[PackSize], fixed-type
    + wineType: array[WineType], fixed-type

### BottleSize 
+ Attributes
    + title: Half (string) - title of the bottle size

### DutyStatus 
+ Attributes
    + title: Duty Paid (string) - title of the duty status

### PackSize 
+ Attributes
    + title: One (string) - title of the package size

### WineType 
+ Attributes
    + title: Red (string) - title of the wine type




