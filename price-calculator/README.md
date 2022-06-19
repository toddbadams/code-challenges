# The Challange
A basket of goods where some have special offers. The test list of items:

- Beans @ 65p per can
- Bread @ 80p per loaf
- Milk @ £1.30 per bottle
- Apples @ £1.00 per bag

The special offers:
- Apples have a 10% discount
- Buy 2 cans of Bean and get a loaf of bread for half price

Input should be via the command line in the form
`PriceCalculator item1 item2 item3 …`

Output should be to the console, for example:
```
Subtotal: £3.10
Apples 10% off: -10p
Total: £3.00
```

If no special offers are applicable the code should output:
```
Subtotal: £1.30
(No offers available)
Total price: £1.30
```