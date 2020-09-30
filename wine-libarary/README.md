

## Enumerations [/enumerations]
 
### List all [GET]
+ Response 200 (application/json)
    + Attributes (array[EnumerationSet], fixed-type)

## EnumerationSet
+ Attributes
    + bottleSize: array[BottleSize], fixed-type
    + bottleSize: array[DutyStatus], fixed-type
    + bottleSize: array[PackSize], fixed-type
    + bottleSize: array[WineType], fixed-type

## BottleSize 
+ Attributes
    + id: 375 (number) - id of the bottle expressed in milliliters
    + title: Half (string) - title of the bottle size

## DutyStatus 
+ Attributes
    + id: DP (string) - id of the duty status expressed as an abbreviation
    + title: Duty Paid (string) - title of the duty status

## PackSize 
+ Attributes
    + id: 1 (number) - id of the package size expressed as the quantity in a package
    + title: One (string) - title of the package size

## WineType 
+ Attributes
    + id: red (string) - id of the wine type expressed as a string
    + title: Red (string) - title of the wine type




