using System;
using System.Numerics;

using Dalamud.Bindings.ImGui;
using Dalamud.Interface.Windowing;

namespace Dalamud.CharacterSync.Interface
{
    /// <summary>
    /// A window that shows warning messages.
    /// </summary>
    internal class WarningWindow : Window, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WarningWindow"/> class.
        /// </summary>
        public WarningWindow()
            : base("Character Sync Message", ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoDecoration | ImGuiWindowFlags.NoTitleBar)
        {
            this.Size = new Vector2(600, 400);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
        }

        /// <inheritdoc/>
        public override void PreDraw()
        {
            ImGui.PushStyleVar(ImGuiStyleVar.WindowPadding, new Vector2(0, 0));
            ImGui.PushStyleColor(ImGuiCol.Text, new Vector4(1.0f, 0.0f, 0.0f, 1.0f));
        }

        /// <inheritdoc/>
        public override void PostDraw()
        {
            ImGui.PopStyleVar();
            ImGui.PopStyleColor();
        }

        /// <inheritdoc/>
        public override void Draw()
        {
            ImGui.SetWindowFontScale(4.0f);
            TextCentered("HEY.");
            
            ImGui.SetWindowFontScale(2.0f);
            ImGui.PushTextWrapPos();
            ImGui.Text("Character Data Sync has just been installed or updated. If this is your first time, please check the settings (you can use /pcharsync in chat). If it's just an update, no need to change anything. No matter what, you need to restart your game now to get everything working.");
            ImGui.PopTextWrapPos();
            TextCentered(" ");
            TextCentered("It's for the safety of your data.");
            
            return;
            void TextCentered(string text)
            {
                ImGui.SetCursorPosX((ImGui.GetWindowSize().X - ImGui.CalcTextSize(text).X) * 0.5f);
                ImGui.Text(text);
            }
        }
    }
}
