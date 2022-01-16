# Algoritmiek

![](https://img.shields.io/github/last-commit/silverfs/algoritmiek)


This project is a console application and a school project used for creating a plan to fill in guests in an event with boxes which contains multiple rows and seats.

Capabilities at execution:
- Places a groups in boxes, filtered from largest group in corresponding to the largest box
  - Groups without an adult don't get placed
  - Children always get placed in the first row
  - If children and adults in a group don't fit in the same box, the group doesn't get placed
- All guests with group ID 0 are guests without a group
  - Children with group ID 0 don't get placed / Only adults get placed
  - Guests first fill up unfilled boxes before they get placed in empty boxes
- The program itself has a menu which can do 3 things
  - Display a List of boxes, filled or not
  - Display a table of Guest
  - Display a table of groups with placement indicators

