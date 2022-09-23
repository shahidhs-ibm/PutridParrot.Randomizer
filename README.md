# PutridParrot.Randomizer

[![Build PutridParrot.Randomizer](https://github.com/putridparrot/PutridParrot.Randomizer/actions/workflows/dotnet-core.yml/badge.svg)](https://github.com/putridparrot/PutridParrot.Randomizer/actions/workflows/dotnet-core.yml)
[![NuGet version (PutridParrot.Randomizer)](https://img.shields.io/nuget/v/PutridParrot.Randomizer.svg?style=flat-square)](https://www.nuget.org/packages/PutridParrot.Randomizer/)
[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/putridparrot/PutridParrot.Randomizer/blob/master/LICENSE.md)
[![GitHub Releases](https://img.shields.io/github/release/putridparrot/PutridParrot.Randomizer.svg)](https://github.com/putridparrot/PutridParrot.Randomizer/releases)
[![GitHub Issues](https://img.shields.io/github/issues/putridparrot/PutridParrot.Randomizer.svg)](https://github.com/putridparrot/PutridParrot.Randomizer/issues)


Extended functionality for Random value generation, includes Concurrent implementation and non-concurrent versions as well as Crypto versions. 

The main aim of this package was three-fold - firstly to create a random number generator interface for mocking out random number generation, secondly to add a thread-safe implementation and thirdly to add extensions to give more functionality to the random number generator.

The core IRandomizer implementations supply the low-level random number generation code, whilst the extension methods supply additions to these, such as generated random strings, dates, etc.
