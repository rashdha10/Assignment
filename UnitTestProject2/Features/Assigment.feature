Feature: Perform CRUD operation for the  Booking

Background: 
Given the token ready for use

Scenario: Get All Booking
Given '/booking'
When the request is made to fetch all booking ids
Then we get all booking ids with 'OK' status

Scenario: Create Booking
Given '/booking'
And the booking details in hand
When the request is made to create a booking
Then we get successful booking with 'OK' status

Scenario: Get Specific Booking Details Of The Book Created
Given the booking id in hand
When the request is made to fetch details of specific book id 
Then we get the details of specific book with 'OK' status

Scenario: Delete Booking
Given the booking id in hand
When the request is made to delete a booking
Then we get all existing booking ids with 'Created' status
