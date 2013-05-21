# Introduction to EventSourcing - The CTM Bank 

This project is designed to provide a playground for learning Distributed Domain Driven Design and CQRS.  
The bank is, by necessity a naïve implementation, there are glaring holes and I wholeheartedly recommend that you don't use it in a production like
banking environment.

### Prerequisites

You will need to install the following components in order to work with the CTM.Bank application.

* MongoDB
* RabbitMQ

To test whether your setup is correct simply run `rake` from the command line, this will run the tests and try to connect to the database.

