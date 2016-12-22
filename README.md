# 3FilesAssignment


3FilesAssignment 

The purpose of this program is to meet the requirements as described in the assignment document.

The program does the following:

    o Runs as a console application from the commandline and loads three files specified:
            FilesAssignment.exe <file Name> <file Name> <file Name>
            
    o The input files should be a data file containing records 
      that have fields separated by one of the following " ", ",", "|"
      
    o Each record in the input files should contain five fields 
       representing the following: lastname, firstname, gender, favorite color and date of birth;
              
    o The records are loaded into a data store and then the data is displayed 
       in 3 formats first sorted by gender with females first then by last name ascending , 
       second sorted by birth date, and third sorted bv lastname descending.
       
    o This project also defines a WFC REST API to access the data using get and add records.
    
    
    The REST API responds to the following:
      o POST /records - with a record defined like those described above for the input files
      o GET /records/gender - returns records sorted by gender
      o	GET /records/birthdate - returns records sorted by birthdate
      o	GET /records/name - returns records sorted by name

    
 
