# what-to-archive
A tool to list folders with the last modified date of their contents to help decide what to archive

# the problem
Windows shows the creation or last copy dates of folders as `Last Modified Date`, not the last modified date of their content files.

Therefore it is not obvious to select folders with old contents that can be archived.

This tool is to help select the folders that can be safely moved to an `old` or `2017` style folder or a `.zip` archive.

# Features
* Can set a folder arg in command line, returns dir list with the max last modified date of their contents
* GUI to browse the folder
* Filter for date
* Move filtered folders to another location
