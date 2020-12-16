# Price Calculator

Price Calculator is .Net Core Console application. This is created as an exercise to calculate prices for a shopping basket

## Requirements

The goods that can be purchased, together with their normal prices are:
- Beans – 65p per can
- Bread – 80p per loaf
- Milk – £1.30 per bottle
- Apples – £1.00 per bag
Current special offers:
- Apples have a 10% discount off their normal price this week
- Buy 2 cans of Bean and get a loaf of bread for half price
The program should accept a list of items in the basket and output the subtotal, the special
offer discounts and the final price.

Input should be via the command line in the form
```
PriceCalculator item1 item2 item3 …
```

## Prerequisites

* .Net Core 3.1
* Visual Studio 2019 with C# / Visual Studio code (for dev environment)

## Run program on command prompt

Copy [Binary folder](https://github.com/keshaavg/price-calculator/tree/master/Binary) locally and run PriceCalculator.App.exe file.
	

## Run in Dev environement

Clone [Repository](https://github.com/keshaavg/price-calculator.git) on local machine and build solution in Visual studio

## Usage

```
PriceCalculator Apple Milk Bread
```

## Test Scenarios (Copied from exercise) 

### Scenario 1
```
PriceCalculator Apple Milk Bread
Output => 
SubTotal: £3.10
Apple 10% OFF: - 10p
Total Price: £3.00
```

### Scenario 2
```
PriceCalculator Beans Bread Milk Apple beans
Output => 
SubTotal: £4.40
Buy 2 Beans Get Bread 50% OFF: - 40p
Apple 10% OFF: - 10p
Total Price: £3.90
```

### Scenario 3
```
PriceCalculator Bread Milk
Output => 
SubTotal: £2.10
(No offers available)
Total Price: £2.10
```

### Scenario 4
```
PriceCalculator  RandomProduct
Output => 
Invalid product name entered
```