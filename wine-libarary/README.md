

## Wine Entries [/wineentries]
 
### Create [POST]
+ Request 
  + **WineEntryRequest**
+ Response 204 
  + array[**WineEntry**]
 
### List all [GET]
+ Response 200 
  + array[**WineEntry**]

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
+ BottleSize: 750 (**BottleSize**) 
+ DutyStatus: IB (**DutyStatus**) 
+ packSize: 6 (**PackSize**) 
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

## Enumerations [/enumerations]
 
### List all [GET]
+ Response 200 
    + body (array[EnumerationSet], fixed-type)

### EnumerationSet
+ bottleSize: array[**BottleSize**], fixed-type
+ dutyStatus: array[**DutyStatus**], fixed-type
+ packSize: array[**PackSize**], fixed-type
+ wineType: array[**WineType**], fixed-type

### BottleSize 
+ title: Half (string) - title of the bottle size

### DutyStatus 
+ title: Duty Paid (string) - title of the duty status

### PackSize 
+ title: One (string) - title of the package size

### WineType 
+ title: Red (string) - title of the wine type


