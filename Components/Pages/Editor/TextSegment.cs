using System.Text.RegularExpressions; // Lägg till denna rad
using System.Collections.Generic;
namespace blazorwebtexteditor.Components.Pages.Editor

{
    public class TextSegment
    {
        
        public string? Text { get; set; } = string.Empty;
        public bool IsBold { get; set; }
        public bool IsItalic { get; set; }
        public bool IsUnderline { get; set; }
        public int FontSizePx { get; set; } = 16;
        public string FontFamily { get; set; } = "Arial";
        public string TextColor { get; set; } = "#000000"; // Black as default
        public bool IsNewLine { get; set; }
        public bool IsSelected { get; set; }
        public bool IsEditing { get; set; }
        
        public void RemoveWord(string wordToRemove)
        {
        if (string.IsNullOrWhiteSpace(Text) || string.IsNullOrWhiteSpace(wordToRemove))
            return;

        // Ta bort ordet från texten och trimma utrymmen
        Text = Text.Replace(wordToRemove, "", StringComparison.OrdinalIgnoreCase).Trim();
        Text = Regex.Replace(Text, @"\s+", " "); // Rensa upp extra utrymmen
        }

        // Dictionary to hold colors for individual words
        public Dictionary<string, string> WordColors { get; set; } = new Dictionary<string, string>();

        // Style for rendering this text segment
        public string GetStyle()
        {
            return $"font-weight: {(IsBold ? "bold" : "normal")}; " +
                   $"font-style: {(IsItalic ? "italic" : "normal")}; " +
                   $"text-decoration: {(IsUnderline ? "underline" : "none")}; " + // Added underline style
                   $"font-family: {FontFamily}; " +
                   $"font-size: {FontSizePx}px; " +
                   $"color: {TextColor};";
        }

        // Method to get the style for a specific word
        public string GetWordStyle(string word)
        {
            // Check if a color is set for this word
            if (WordColors.ContainsKey(word))
            {
                return $"color: {WordColors[word]};"; // Return color style if exists
            }

            return string.Empty; // No specific color, return empty
        }
    }
}
