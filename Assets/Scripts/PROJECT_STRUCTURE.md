# Project Script Structure

## 📁 Scripts Organization

### 🎨 UI/
- **Windows/** - All window classes (MainMenu, Settings, Share, etc.)
- **Components/** - UI components (buttons, layouts, screen formatting)
- **Elements/** - UI elements (previews, images, text elements)
- **Animations/** - UI animation controllers

### 💾 Data/
- **Models/** - Data models and enums
- **SavedWork/** - Save/load functionality for user work
- **Serialization/** - Serialization utilities
- **Config/** - App configuration and constants

### 🎮 Gameplay/
- **ColoringSystem/** - Number coloring and texture coloring logic
- **DailyGame/** - Daily challenge features
- **Tutorial/** - Tutorial system and pages
- **Workbook/** - Workbook management
- Game scenes and core gameplay logic

### 🕹️ Controls/
- **Input/** - Input receivers and handlers
- **Camera/** - Camera controllers and management
- **Touch/** - Touch and multi-touch handling

### 📱 Platform/
- **Share/** - Native sharing functionality
- **Ads/** - Advertisement wrappers
- **Firebase/** - Firebase integration
- **Permissions/** - Camera and permission handlers

### 🛠️ Utils/
- **Extensions/** - Extension methods
- **Pooling/** - Object pooling systems
- **JSON/** - JSON parsing utilities
- **Crypto/** - Encryption/hashing utilities
- General helper classes and debug tools

### 🏗️ Managers/
- Core managers (Main, Audio, Data, Window, etc.)
- Controllers for various game systems

### 🧭 Navigation/
- Scene navigation system
- Navigation arguments and base scenes

### 🎯 Special Modules
- **MagicaVoxel/** - Voxel model loading and rendering
- **Helpers/** - Unity-specific helpers
- **GameBase/** - Base game scene classes
- **AU/** - Editor utilities

## Benefits of This Structure:
1. **Clear separation of concerns** - Each module has a specific purpose
2. **Easy navigation** - Find scripts quickly based on functionality
3. **Better maintainability** - Related code is grouped together
4. **Scalability** - Easy to add new features in appropriate modules
5. **Reduced coupling** - Clear boundaries between different systems