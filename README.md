# anonimzwx site (Blazor Web App, .NET 10, Visual Studio 2026)

Open `AnonimzwxSite.sln` and press F5.

## Edit content (no rebuild, just refresh the browser)
| What | File |
|---|---|
| "Who am I?" texts, links, tech, highlights | `wwwroot/data/about.json` |
| Unity projects | `wwwroot/data/unity.json` |
| SNES projects | `wwwroot/data/snes.json` |

### Add a project
Copy a block in `unity.json` / `snes.json`, paste it, edit it:

    {
      "title": "My project",
      "description": "What it is.",
      "tags": ["Unity", "VR"],
      "media": [
        "https://www.youtube.com/watch?v=XXXXXXXXXXX",
        "media/unity/demo.gif",
        "media/unity/clip.mp4"
      ]
    }

- YouTube links load only when clicked. `.mp4`/`.webm` loop with no sound. Anything else is shown as an image (webp, png, jpg, gif).
- Put your files in `wwwroot/media/unity/` or `wwwroot/media/snes/`.
- Several media items in one project scroll sideways inside the card.
- Projects appear in the same order as in the file.

## Contact form email
1. Set `Smtp:Host`, `Port`, `User`, `To` in `appsettings.json`.
2. Right-click the project > **Manage User Secrets** and add:

       { "Smtp": { "Password": "your-app-password" } }

   Gmail needs an App Password (2-step verification on), not your normal password.
3. The email arrives in the `To` inbox with the visitor's email as Reply-To, so "Reply" answers them.
