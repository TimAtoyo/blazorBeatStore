module.exports = {
  content: [
    "./Pages/**/*.{razor,html,cshtml}", // Scans Blazor component pages
    "./Shared/**/*.{razor,html,cshtml}", // Scans shared components
    "./wwwroot/**/*.html", // Includes static HTML files
    "./**/*.razor", // Ensures all Razor files are covered
    "./**/*.cs", // Useful if class-based styling is used
  ],
  theme: {
    extend: {},
  },
  plugins: [],
};
