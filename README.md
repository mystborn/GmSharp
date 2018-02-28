# TaffyScript
## What is TaffyScript?
Taffy is a dynamic programming language based heavily off of Gamemaker language, 
which is the scripting language used inside of the game engine Gamemaker.

## Features
* Built in C#
* Compiles into a valid .NET assembly
* Dynamic Typing
* Does not use DLR
* Accessable from existing .NET projects
* Import external .NET methods.
* Reflection (WIP)

## Sounds Great! How Can I Get it?
Currently the only way to acquire Taffy is to build it from the source, however that will be changing soon.

## Example Code
```cs
script main {
    show_debug_message("Hello, World!");
    var user = instance_create(obj_user);
    user.name = "Taffy";
    instance_destroy(user);
    show_debug_message("Closing...");
}

object obj_user {
    event create {
        name = "";
    }

    event destroy {
        show_debug_message("Goodbye, " + name);
    }
}

// Output:
// Hello World!
// Goodbye, Taffy
// Closing...
```

## What's Left?
* Base class library (High)
* Namespace/module system (Mid)
* Constant values i.e. macros (Mid)
* C style import (Low)

## Breaking Changes
As mentioned earlier, the language is based off of GML. However, in order to be usable, some things had to change. Here's a list of some the biggest changes.
* Asset Ids: In GM, all assets (scripts, object, etc) are given a numerical id that you can use to refer to them. In Taffyscript, assets are referred to using their name (aka a string).
* Asset Declaration: In Taffyscript, you declare all assets and their type inside of the code. No more clicking on the objects folder to find the type that you're looking for.

I've tried to keep the list of changes as small as possible (sometimes to the decrement of the language). Any code that works in GM will essentially work in TaffyScript, and the reverse is also true.