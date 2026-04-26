namespace GUI_62_RS
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            LogIn_62_RS login_62_RS = new LogIn_62_RS();

            if (login_62_RS.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Administracion_62_RS());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}