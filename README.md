# Project 2: More Videotapes Galore :vhs:
## Project 2 for T-302-HONN

Áslákur’s cousin, Dósóþeus Tímóteusson (a well known poet and philosopher), took a course on software design and construction and has offered to design the system. You’ve graciously agreed to help out by implementing the system based Dósóþeus’s designs.
The design is based on microservices where the functionality is broken down into individual services although to simplify the implementation, the services are not required to run independently and the data may be stored in a single central repository.

### REST API
- [x] /tapes [GET] - Get information about all tapes
- [x] /tapes [POST] - Add tape
- [x] /tapes/{tape_id} [GET] - Get information about a specific tape
- [x] /tapes/{tape_id} [DELETE] - delete a tape
- [x] /tapes/{tape_id} [PUT] - Update a tape
- [x] /users [GET] - Get information about all users
- [x] /users [POST] - Add a user
- [x] /users/{user_id} [GET] - Get information about a given user
- [x] /users/{user_id} [DELETE] - Remove a user
- [x] /users/{user_id} [PUT] - Update a user
- [x] /users/{user_id}/tapes [GET] - Update information about the tapes a given user has on loan
- [x] /users/{user_id}/tapes/{tape_id} [POST] - Register a tape on loan
- [x] /users/{user_id}/tapes/{tape_id} [DELETE] - Return a tape
- [x] /users/{user_id}/tapes/{tape_id} [PUT] - Update borrowing information
- [x] /users/{user_id}/reviews [GET] - Get reviews by a given user
- [x] /users/{user_id}/reviews/{tape_id} [GET] - Get user reviews for a given tape
- [x] /users/{user_id}/reviews/{tape_id} [POST] - Add a user review for a tape
- [x] /users/{user_id}/reviews/{tape_id} [DELETE] - Remove review
- [x] /users/{user_id}/reviews/{tape_id} [PUT] - Update tape review
- [x] /users/{user_id}/recommendation [GET] - Get a recommendation for a given user
- [x] /tapes/reviews [GET] - Get reviews for all tapes
- [x] /tapes/{tape_id}/reviews [GET] - Get all reviews for a given tape
- [x] /tapes/{tape_id}/reviews/{user_id} [GET] - Get a user's review for a tape
- [x] /tapes/{tape_id}/reviews/{user_id} [PUT] - Update a user's review
- [x] /tapes/{tape_id}/reviews/{user_id} [DELETE] - Remove a user's review
