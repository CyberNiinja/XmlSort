##################   DESCRIPTION   #########################################################

This Program iterates over a specified directory ~ looking for xml files.
It looks for a specified XML tag in every file. 
If a tag is found, the first occurence in a file is checked for specified content:
If the content of the xml tag matches the desired content, the file is moved to the ~/desired directory
If the content of the xml tag doesnt match the desired content, the file is moved to the ~/undesired directory
If the desired xml tag isnt found in a file, the file is skipped. 

############################################################################################

##################   EXECUTABLE   #########################################################

The SELFCONTAINED executable is found in XMLSearch Folder. 
It runs on Windows x86 Platform.
A publishing Profile is created for x86 selfcontained. 

############################################################################################