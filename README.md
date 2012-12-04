Notepad++ Transform Example
===================

This project is a SrcML Transform project that relies on the [ABB Visual Studio Program Transformation tool][1]. This code was used in a tool demonstration given at [FSE 2012][3]. The slides are available [here][7].

## Background

We want to demonstrate a fairly wide-ranging code transformation on a real piece of software. In this demo, we want to ensure that all uses of the `new` operator are wrapped in a `try`/`catch` block in order to check for errors. This was a compiler change seen in [Visual Studio 2005][6]:

> By default, any call to new that fails will throw an exception.

Microsoft provided other ways adapt to this change, but for our purposes, we will assume that the best change is to modify the source code in order to reflect the C++ standard.

## Setup

In order to run this code, there are a few setup steps.

First, download [SrcML.NET][1] and install the program transformation Visual Studio add-in (see the [README][2] for details).

Second, download the code for [Notepad++][4] and extract it somewhere on disk. I used [version 6.2][5] in the demonstration, but the transformations should work on other versions as well.

## The Demo

The demonstration is fairly straightforward.

1. Launch Visual Studio
2. Open the "NPPTransformExample" project
3. Enable the "Program Transformation" addin from the add-ins menu. The "transformation preview pane" should appear.
4. Select the first "Browse..." button to select a source folder.
  1. Navigate to the downloaded copy of Notepad++
  2. Select the "PowerEditor" directory
  3. Press "OK"
  4. The buttons will disable briefly while the source code is converted into srcML.
4. Build the project -- the add-in should update saying that three transformations have been loaded.
5. You can now play with any of the provided transformations. There are three:
  1. `AllNewQuery`: This is used to demonstrate a basic query and to explore how the `new` operator is used in Notepad++. You can use the category view on the left to see what kinds of statements `new` operators appear in.
  2. `NewExpressionTransform`: This is used to transform all uses of the `new` operator that occur in *expression* statements.
  3. `NewDeclarationTransform`: This is used to transform all uses of the `new` operator that occur in *declaration* statements.

In order to preview a transform, simply press "Test". You can double click on any of the results to see the original source code. Once you're happy with the results, select an output directory (the 2nd "Browse..." button) and then press "Execute." Notepad++ compiles, runs, and operates without error. This is exactly what we want for an adaptive maintenance change!

[1]: https://github.com/abb-iss/SrcML.NET
[2]: https://github.com/abb-iss/SrcML.NET#readme
[3]: http://www.sigsoft.org/fse20/
[4]: http://notepad-plus-plus.org/
[5]: http://notepad-plus-plus.org/news/notepad-6.2-release-udl2.html
[6]: http://msdn.microsoft.com/en-US/library/vstudio/h4bcz65t(v=vs.80).aspx
[7]: http://www.slideshare.net/vinayaugustine/automating-adaptive-maintenance-changes-with-srcml-and-linq