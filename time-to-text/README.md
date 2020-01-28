
## Time of day to text challenge
Given a time of day, convert it to human-readable text.

### Console application
Write a command-line program that returns the current time as human-readable text.

| Numeric Time | Text |
|--------------|------|
| 0:00 | Midnight |
| 24:00 | Midnight |
| 00:30 | Half past midnight |
| 001 | One past midnight |
| 12:00 | Noon |
| 1200 | Noon |
| 11:31 | Twenty nine to noon |
| 12:03 | Three past noon |
| 1:00 | One o'clock |
| 13:00 | One o'clock |
| 13:05 | Five past one |
| 13:10 | Ten past one |
| 13:21 | Twenty one past one |
| 13:22 | Twenty two past one |
| 13:23 | Twenty three past one |
| 13:24 | Twenty four past one |
| 13:25 | Twenty five past one |
| 13:26 | Twenty six past one |
| 13:27 | Twenty seven past one |
| 13:28 | Twenty eight past one |
| 13:29 | Twenty nine past one |
| 13:30 | Half past one |
| 13:35 | Twenty five to two |
| 13:55 | Five to two |
| 23:55 | Five to midnight |

### Arbitrary time
Allow the command to take an arbitrary Numeric Time. Return an invalid message when the time is not well formated.  Permitted time entries may or may not include a colon and may or may not have leading zeros.

### REST API
Write a REST service to expose the clock and allow an optional parameter, returning as JSON.
