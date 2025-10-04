# Fixing Unity References After Refactoring

## Issue
After moving scripts to new folders, Unity may have lost some references because:
1. Prefab references to scripts might be broken
2. Scene GameObjects might have missing script references
3. The PrefabLoader singleton might not be initialized

## Solutions

### 1. Fix PrefabLoader Instance
**In your main scene or persistent scene:**
- Find the GameObject with `PrefabLoader` component
- Make sure it's active and the component is enabled
- Check that the `windows` array is populated with all your window prefabs

### 2. Reimport All Assets
In Unity Editor:
- Right-click on the Assets folder
- Select "Reimport All"
- This will force Unity to rebuild all references

### 3. Check Scene References
1. Open your main scene
2. Look for any GameObjects with missing script warnings (they'll show as "Missing (Mono Script)")
3. For each one:
   - Note what component it should be
   - Remove the missing component
   - Add the component again from its new location

### 4. Check Prefab References
1. Open each prefab in the Prefabs folder
2. Look for missing script references
3. Reassign scripts from their new locations

### 5. Common Broken References to Check:
- **WindowManager** - Should reference all window prefabs
- **PrefabLoader** - Should have windows array populated
- **MainManager** - Core game management references
- **GameController** - Game scene references

## Prevention for Future
- Always move files through Unity Editor (not file system)
- Or ensure .meta files are preserved when moving
- Consider using assembly definitions for better modularity

## Quick Debug
The PrefabLoader now has better error logging. Run the game and check the Console for:
- "PrefabLoader instance is null!" - PrefabLoader not in scene
- "PrefabLoader windows array is null or empty!" - Windows array not set
- "Window with name 'X' not found" - Specific window missing from array