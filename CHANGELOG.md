# Changelog

All notable changes to this project will be documented in this file.

The format is based on **Keep a Changelog** and follows **Semantic Versioning**.

---

## [2.0.0] - 2026-11-17

### Added
- **ToDoWpf Desktop GUI**: Native desktop interface built with Windows Presentation Foundation (WPF) targeting .NET 10 (`net10.0-windows`).
- **Real-Time Dynamic Search**: Instant filtering via `SearchBox` that refreshes the task list dynamically as characters are entered (`TextChanged`).
- **Dedicated Modal Dialogs**:
  - `AddTaskWindow`: Modal dialog to register tasks with dedicated Title and multi-line Description inputs.
  - `Edit` Window: Modal dialog pre-filled with the current task's Title and Description for seamless inline updates.
- **Automated Daily Task Reset**: Intelligent reset system for recurring daily habits; completed tasks automatically reset their completion state every 24h / on the next calendar day (`Date` tracking).
- **Interactive Checkbox Controls**: `ToggleButton` integration for toggling task completion status in real-time.
- **Defensive Task Deletion**: Confirmation dialog (`MessageBox.Show` with Yes/No) to prevent accidental task removal.
- **Visual Documentation & Wireframes**: Added UI wireframes and application screenshots under `docs/wireframes/`.

### Changed
- **Multi-Project Architecture**: Refactored solution to decouple UI layers (`ToDoWpf` for desktop and `ToDoList` for console) from shared business logic and data models.
- **Filesystem Persistence Location**: Migrated JSON storage path to `%LOCALAPPDATA%\ToDoWpf\tasks.json` (`Environment.SpecialFolder.LocalApplicationData`), complying with Windows user-data standards.
- **Enhanced Data Model**: Extended `TaskItem` with a `Date` property to record the timestamp of completion for automated daily resets.
- **Indented JSON Serialization**: Improved `JsonService` to format JSON with indentation (`WriteIndented = true`) and added resilient handling for empty or malformed files.

### Fixed
- Fixed completion toggle button state retention when filtering tasks through the search box.
- Fixed daily reset execution timing by executing date validation at window initialization.
- Fixed edit modal form loading blank fields; fields now retain and display existing task details.

---

## [1.0.0] - 2026-07-25

### Added

- Complete CRUD functionality
- Search tasks by name or number
- Input validation
- Error handling
- JSON persistence
- Automatic loading of saved tasks
- Task completion status

### Changed

- Refactored project structure
- Separated responsibilities into Models, Services and Helpers
- Improved project organization and readability

### Fixed

- Search by task name
- Task index validation
- Exception handling during JSON loading
