# The CTM Bank Stories

For all stories strict validation of the command line input is not necessary, it's not the most interesting part of the story!  
Feel free to do it in your own time though!

### Story 1 - Deposit Money

As a customer, I want to be able to deposit money into my bank account, so that I can save money for the latest gadgets

*Given* that I am at the command prompt and I have an account created
*When* I type: 'deposit 50.00'
*Then* I should see a message confirming that I have deposited £50.00

#### Acceptance Criteria

1. The amount to deposit should always be positive
2. Valid amounts include: `£50.00`, `£50`, `50`, `50.00` (Amounts with no currency symbol will default to GBP)


### Story 2 - Withdraw Money

As a customer, I want to be able to withdraw money from my bank account, so that I can spend my money on the latest gadgets

*Given* that I am at the command prompt and I have an account
*When* I type: 'withdraw 50.00'
*Then* I should see a message confirming that I have withdrawn £50.00

### Story 3 - Disable Overdrafts

As a bank, I want to prevent my customers from withdrawing more money than exists in their account, so that I don't rapidly go out of business

*Given* that I am at the command prompt and I have an account with a balance of less than £50.00
*When* I type: 'withdraw 50.00'
*Then* I should see a message which explains that I can't be overdrawn
