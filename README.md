# Advanced Siebel Log Scanner
#### Community Advantage thru Crowdsourcing

The log scanner is a simple Siebel AOM log analyser. It anlayses the log and classifies the various events in the logs into diffrent sections of the tool.
The Idea of the tool is CROWDSOURCING, solutions of the errors under the error log tab can edited. the same solutions will be updated in the cloud DB and will synced across other users via ErrorDef update.
Hence more the users better the information and this can only keep growing.

# Features in this Release

  - Performance Analysis: SQL's ran in the application and can be sorted based on the time taken and the base tables used
  - workflow and the task steps in the order of execution.
  -  displays the various events occured as part of executions.
  -  Error Messages listing
  -  Embeded NoSQL db to record the solutions so that in case on next occurance of issue the soultions are already present.
  -  None of the object specific data is stored in the cloud and hence this shouldnt cause any compliance issues.
  -  Notepad++ integration to quickly goto the line in Notepad++
  -  On selecting log in the File Select Tab the right group of text boxes displays the Log specific details.

You can also:
  - Update the latest ErrorDef.json (avalible on gitHub) to make sure you have latest solution to the errors 

This is a lightweight tool and since its in its inital version might still contain some bugs.You can falg on [gitHub][df1] for any feature requests or issues.

Make sure you pick the latest version of Application and ErrorDef from [here]

### Tech

Dillinger uses a number of open source projects to work properly:

* [LiteDB] - NoSQL Based lite and fast DB
* [MongoDb] - one of the best cloud based NoSQL DB

And of course C# for all the other stuff.

### Installation

1) This is a standalone tool based on the .Net Framework 4.5
> Make sure you have .Net Framework 4.5+

2)Download the Application and ErrorDef.json

3)Link the Notepad++.exe from the File Select Tab
>This is optional but if linked the tool will open the error on the Notepad++ when asked to open the error on Notepad++

4) Update the Tools internal Error Defination.
>Goto About tab and click UpdateDef button to upda the error definations.

5) And you are ready to use it
>Use Browse button to select log and analyse button to process it.

### Development

Want to contribute? Great! let me know via mail.

### Todos

 - Currently sync is manual , planning to automate it like any antivirus definations ;)
 - Add Export to file option.

**Free Software, Hell Yeah!**


   [df1]: <https://github.com/vijaykirann/SiebLog-Analyser/issues>
   [here]: <https://github.com/vijaykirann/SiebLog-Analyser/releases>
   [LiteDb]: <https://github.com/mbdavid/LiteDB>
   [MongoDb]: <https://github.com/mongodb/mongo>
