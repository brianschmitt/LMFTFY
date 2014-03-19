(LMFTFY) Let me find that for you
=================================

A Visual Studio extension that performs predefined search terms.

This will add a new menu item "LMFTFY" in your Visual Studio Instance.
The extension simply opens the Find All dialog and based on your selected item, sets some predefined criteria.
For example - You can now do a global find for

- All regions
- Deprecated or Hard-Coded styles
- Repeated blank lines
- Trailing white space
- Empty catch blocks
- Commented out code

Additionally you can click the menu item, but before you initiate the search, change the dialog to replace.
For example you can quickly replace all regions in all code files, but simply leaving the "replace with" empty.

Background
Old blog posts of mine provided the beginings for this, and I decided to roll them into an extension. Visual Studio has always had regular expression searching. The problem is remembering the correct search term consistently over time.
I used to keep a small text file with some that I had used. I wanted to bring those searches into a single easy to find location and to share it with others.

Did you find an issue? Did a search not work as expected? Do you have any suggestions?
Please open an issue with any problems you may encounter with the search regular expression and provide a sample code for what failed.

Improvements
I am looking to improve the commented code and deprecated/hard-coded styles searches.
If you have any suggestions or are a Regular Expression wizard, please feel free to submit an issue or pull request.