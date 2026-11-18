# 📂 Smart File Organizer

A rule-based, automatic file organization engine developed for Windows. Operating quietly in the background with near-zero CPU footprint, it continuously monitors your chosen target directory (e.g., Downloads or Desktop) and instantly categorizes new files into appropriate subfolders based on their extensions.

## 🚀 Key Features

*   **Event-Driven Architecture:** Instead of using resource-heavy continuous while-loops, it utilizes the Windows `FileSystemWatcher` class. The engine is triggered only when a new file hits the file system, ensuring optimal performance.
*   **Stealth Operation (System Tray):** No intrusive windows or pop-ups. The application runs seamlessly in the background, minimizing to the System Tray (NotifyIcon).
*   **I/O Lock Safety:** Includes intelligent download detection. It verifies if a file (from Chrome, Edge, etc.) is still being written to disk and waits for the lock to release before attempting to move it, preventing file corruption or application crashes.
*   **Dynamic Extension Dictionary:** Employs a robust `Dictionary<string, string>` data structure to map over 130+ file extensions. This allows for *O(1)* time complexity lookups, routing files to their destinations instantly.
*   **Collision Handling:** Automatically indexes files (e.g., `file (1).pdf`) if a file with the same name already exists in the destination folder, preventing data overwrite.

## 🛠️ Tech Stack

*   **Language:** C# (.NET)
*   **UI Framework:** Windows Forms (WinForms)
*   **Configuration:** Local JSON-based settings storage (`Newtonsoft.Json`)
*   **OS Integration:** Windows System Tray API & File I/O Management

## 📥 How to Use

If you prefer not to compile the code from source:
1. Navigate to the **Releases** section on the right sidebar and download the latest `.exe` file.
2. Run the application and select the target directory you want to organize (e.g., Downloads).
3. Click "Save and Start". The application will minimize to the System Tray and begin sorting your files automatically.

---
*This project was developed to automate daily workflow friction and demonstrate practical experience with Windows Background Processes and File I/O architectures.*
