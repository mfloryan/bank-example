# Exercises

## 1. Intro to Aggregates: Implement the stories

This exercise is to allow people to focus on the new concepts of AggregateRoots and how they work with EventSourcing.  A simple Aggregate (`Account`) has been created
with tests, this exercise is to add more behaviour by implementing the stories.

## 2. Intro to Value Types: Recreate the Money class 

This exercise is to allow people to get hands on experience working with Value types, what they are, how to recognise and create them.  
This is an independent exercise not solely focussed on CQRS & EventSourcing but ideal for people who want to focus on Value types & Object-Orientation.

To get started type: `git checkout implement-money` and run the tests, one failing test `ShouldDetermineEquality` is failing, fix it :)

Once the test is fixed additional tests can be copied (one at a time) from `src/CTM.Bank.Tests/Unit/AdditionalMoneyTests.cs` 
(You can include this test in the project if you wish) or write your own.

## 3. Intro to Projections: Implement the Balance story

This exercise should be picked up after Exercise 1 and will deal with the creation of a projection and the code required to receive events and write them into a format 
suitable for reading.

## 4. Intro to the Packages: Install and setup the packages for working with CQRS and Event Sourcing

This is an 'advanced' exercise for those people who have completed the previous three exercises.  This exercise will teach you how to get started with EventSourcing on a brand 
new project, what you need to do and the packages you need to install.