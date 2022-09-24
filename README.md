# PutridParrot.Randomizer

[![Build PutridParrot.Randomizer](https://github.com/putridparrot/PutridParrot.Randomizer/actions/workflows/dotnet-core.yml/badge.svg)](https://github.com/putridparrot/PutridParrot.Randomizer/actions/workflows/dotnet-core.yml)
[![NuGet version (PutridParrot.Randomizer)](https://img.shields.io/nuget/v/PutridParrot.Randomizer.svg?style=flat-square)](https://www.nuget.org/packages/PutridParrot.Randomizer/)
[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/putridparrot/PutridParrot.Randomizer/blob/master/LICENSE.md)
[![GitHub Releases](https://img.shields.io/github/release/putridparrot/PutridParrot.Randomizer.svg)](https://github.com/putridparrot/PutridParrot.Randomizer/releases)
[![GitHub Issues](https://img.shields.io/github/issues/putridparrot/PutridParrot.Randomizer.svg)](https://github.com/putridparrot/PutridParrot.Randomizer/issues)


Extended functionality for Random value generation, includes Concurrent implementation and non-concurrent versions as well as Crypto versions. 

The main aim of this package was three-fold - firstly to create a random number generator interface for mocking out random number generation, secondly to add a thread-safe implementation and thirdly to add extensions to give more functionality to the random number generator.

The core IRandomizer implementations supply the low-level random number generation code, whilst the extension methods supply additions to these, such as generated random strings, dates, etc.

## Usage

Install the latest package from nuget, for example by running 

```
dotnet add package PutridParrot.Randomizer --version 1.0.6-alpha
```

In usages we simply use something like the following

```
using PutridParrot.Randomizer;

var randomizer = new PseudoRandomizer();
var value = randomizer.NextDate(DateTime.Now.AddDays(30));
```

_In the example above we're using the NextDate method to give us a random date between DateTime.Now and up to, but less than, 30 days in the future._

## API

This is just an overview of the API, in most cases we'll have versions of NextXXX where XXX will be a Long, Double, Bool or whatever. In some cases an API will have a version with no arguments, this defaults to [0, MAX_VALUE(type)[. In other words from 0 through to int.MaxValue or whatever the type's max value is. The second type of method generally takes a single argument to replace the max value and then the third version will take min and max values.

### NextInt

Gets a random integer

```
var value = randomizer.NextInt();
```

### NextByte

Gets a random byte

```
var value = randomizer.NextByte();
```

### NextDouble

Gets a random double

```
var value = randomizer.NextDouble();
```

### NextLong

Gets a random long

```
var value = randomizer.NextLong();
```

### NextBool

Gets a random boolean

```
var value = randomizer.NextBool();
```

### NextDateTime

Gets a random DateTime

```
var value = randomizer.NextDateTime();
```

### NextDate

Gets a random DateTime where the .Date is passsed back

```
var value = randomizer.NextDate();
```
### NextItem

Get a random item from a list with

```
var value = randomizer.NextItem(new [] { 1, 2, 3, 4, 5 });
```

### NextItem

Get a random enum value from a supplied Enum type

```
var value = randomizer.NextEnum<SomeEnum>();
```

### Shuffle

Shuffle a supplied IList of items. 

_Note: Whilst this returns the original IList, the IList is mutated, if you want to keep the original
IList in order, clone the list before passing it into Shuffle._

```
var value = randomizer.Shuffle(new [] { 1, 2, 3, 4, 5 });
```

## NextGaussian

```
var value = randomizer.NextGaussian();
```

## NextString

Gets a random string of the given length (in the example below the length is 10) and generate the string
from the character set supplied (in this example it's all alpha characters only)

```
var value = randomizer.NextString(10, "abcdefghijklmnopqrstuvwxyz");
```

## NextList

Gets a random IList of type T of the given length (in the example below the length is 10). The random IList is generated
from the available values in the supplied list (in this example the random list will be 10 items taken from [1, 5] values)

```
var value = randomizer.NextList(10, new [] { 1, 2, 3, 4, 5 });
```
