using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Proxies;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services.Protocols;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Text;
using System.Xml.Linq;
using System.Collections;
using System.ServiceModel;
using Microsoft.Win32;
using System.Windows.Forms;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;
using SaveFileDialog = System.Windows.Forms.SaveFileDialog;
using Newtonsoft.Json.Linq;
using System.Net;

/*
 Initial Creator: Cameron Smith
 SURF STUDENT
 SUMMER 2019
 */

namespace HL7ClientProject
{
    public partial class WebServiceAggregator : System.Web.UI.Page
    {
        //these below are static fields that can be updated at any time within any method

        public static string message1;
        public static string profile1;
        public static string constraints1;
        public static string valueSetLibrary1;
        public static string messageId1;

        //these below are more static fields for the filenames the user will be uploading (Profile, Constraints, Message, ValueSetLibrary)

        public static string filename1 = "";
        public static string filename2 = "";
        public static string filename3 = "";
        public static string filename4 = "";


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //here below is the button for Example validation with Resources and its contents
        protected void Button3_Click(object sender, EventArgs e)
        {

            //We make an example client below and create a string with the message ID of the hardcoded profile in the program Solution explorer
            //That profile file, constraints, valuesetlibrary, and message.txt are all stored as embedded resources in our project, allowing us to use the code below

            HL7WebService.MessageValidationV2InterfaceClient client = new HL7WebService.MessageValidationV2InterfaceClient();
            string messageId = "aa72383a-7b48-46e5-a74a-82e019591fe7";

            // in the code below we store the message in a string called message using embedded resource Z22Message.txt

            var assembly = Assembly.GetExecutingAssembly();
            // var resourceName = "Z22Message.txt";

            string resourceName = assembly.GetManifestResourceNames()
            .Single(str => str.EndsWith("Z22Message.txt"));

            Stream stream = assembly.GetManifestResourceStream(resourceName);
            StreamReader reader = new StreamReader(stream);

            string message = reader.ReadToEnd();



            // in the code below we store the Constraints in a string called constraints using embedded resource VXU-Z22_Constraints.xml

            var assembly1 = Assembly.GetExecutingAssembly();
            // var resourceName = "Z22Message.txt";

            string resourceName1 = assembly1.GetManifestResourceNames()
            .Single(str => str.EndsWith("VXU-Z22_Constraints.xml"));

            Stream stream1 = assembly1.GetManifestResourceStream(resourceName1);
            StreamReader reader1 = new StreamReader(stream1);

            string constraints = reader1.ReadToEnd();



            // in the code below we store the valueSetLibrary in a string called valueSetLibrary using embedded resource VXU-Z22_ValueSetLibrary.xml

            var assembly2 = Assembly.GetExecutingAssembly();
            // var resourceName = "Z22Message.txt";

            string resourceName2 = assembly2.GetManifestResourceNames()
            .Single(str => str.EndsWith("VXU-Z22_ValueSetLibrary.xml"));

            Stream stream2 = assembly2.GetManifestResourceStream(resourceName2);
            StreamReader reader2 = new StreamReader(stream2);

            string valueSetLibrary = reader2.ReadToEnd();


            // in the code below we store the profile in a string called profile using embedded resource VXU-Z22_Profile.xml

            var assembly3 = Assembly.GetExecutingAssembly();
            // var resourceName = "Z22Message.txt";

            string resourceName3 = assembly3.GetManifestResourceNames()
            .Single(str => str.EndsWith("VXU-Z22_Profile.xml"));

            Stream stream3 = assembly3.GetManifestResourceStream(resourceName3);
            StreamReader reader3 = new StreamReader(stream3);

            string profile = reader3.ReadToEnd();

            // Finally, we combine all these strings into the method validateWithResources from the WSDL and get our result which we display in the text box

            TextBox1.Text = client.validateWithResources(message, profile, constraints, valueSetLibrary, messageId);

            //This code below is what grabs the counts and displays them

            var myJsonString = client.validateWithResources(message, profile, constraints, valueSetLibrary, messageId);
            var jo = JObject.Parse(myJsonString);
            var errors = jo["metaData"]["counts"]["error"].ToString();
            var warnings = jo["metaData"]["counts"]["warning"].ToString();
            var affirmatives = jo["metaData"]["counts"]["affirmative"].ToString();

            Label10.Text = "Report Counts: " + "Errors - " +errors + " | Warnings - " + warnings + " | Affirmatives - " + affirmatives;

        }

        // below is the button for getServiceStatus
        protected void Button1_Click(object sender, EventArgs e)
        {

            //Makes the Client

            HL7WebService.MessageValidationV2InterfaceClient client = new HL7WebService.MessageValidationV2InterfaceClient();



            string status = client.getServiceStatus();



            TextBox2.Text = status;
        }


        //below is the button for validate Message
        protected void UploadButton_Click(object sender, EventArgs e)
        {

            //I make the client
            HL7WebService.MessageValidationV2InterfaceClient client = new HL7WebService.MessageValidationV2InterfaceClient();

            //this chunk below deals with uploading the message.txt (in the markup code, I specify that this filedialog should prompt for a .TXT file)
            if (FileUploadControl.HasFile)
            {
              //  try
              //  {
                    filename1 = Path.GetFileName(FileUploadControl.FileName);
                    FileUploadControl.SaveAs(Server.MapPath("~/UploadMessage/") + filename1);
                   // StatusLabel.Text = "Upload status: File uploaded!";
                  WebServiceAggregator.message1 = System.IO.File.ReadAllText(@"C:\Users\Owner\source\repos\HL7ClientProject\HL7ClientProject\UploadMessage\" + filename1);
                  // LblValidateWithResources.Text = client.validateWithResources(text, profile, constraints, valueSetLibrary, messageId);
                  // ValidateWithResourcesTextBox.Text = client.validateWithResources(text, profile, constraints, valueSetLibrary, messageId);
              //  }
              //  catch (Exception ex)
              //  {
                 //   StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
              //  }

            }


            //this chunk below deals with uploading the profile.xml (in the markup code, I specify that this filedialog should prompt for a .XML file)
            if (FileUploadControl0.HasFile)
            {
             //   try
              //  {
                    filename2 = Path.GetFileName(FileUploadControl0.FileName);
                    
                    FileUploadControl0.SaveAs(Server.MapPath("~/UploadProfile/") + filename2);
                   // StatusLabel0.Text = "Upload status: File uploaded!";
                    WebServiceAggregator.profile1 = System.IO.File.ReadAllText(@"C:\Users\Owner\source\repos\HL7ClientProject\HL7ClientProject\UploadProfile\" + filename2);
                    // LblValidateWithResources.Text = client.validateWithResources(text, profile, constraints, valueSetLibrary, messageId);
                    // ValidateWithResourcesTextBox.Text = client.validateWithResources(text, profile, constraints, valueSetLibrary, messageId);

                    //these lines below grab the message ID value from the profile for the Validate With Resources method
                    WebServiceAggregator.messageId1 = XDocument.Load(@"C:\Users\Owner\source\repos\HL7ClientProject\HL7ClientProject\UploadProfile\" + filename2).Root
                       .Descendants("Message")
                       .Select(element => element.Attribute("ID").Value).FirstOrDefault();
               // }
               // catch (Exception ex)
               // {
                 //Label12.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
              //  }

            }

            //LblValidateWithResources.Text = client.validateWithResources(text, profile, constraints, valueSetLibrary, messageId);


            //this chunk below deals with uploading the constraints.xml (in the markup code, I specify that this filedialog should prompt for a .XML file)
            if (FileUploadControl1.HasFile)
            {
              //  try
              //  {
                    filename3 = Path.GetFileName(FileUploadControl1.FileName);
                    FileUploadControl1.SaveAs(Server.MapPath("~/UploadConstraints/") + filename3);
                    //StatusLabel1.Text = "Upload status: File uploaded!";
                    WebServiceAggregator.constraints1 = System.IO.File.ReadAllText(@"C:\Users\Owner\source\repos\HL7ClientProject\HL7ClientProject\UploadConstraints\" + filename3);
                    // LblValidateWithResources.Text = client.validateWithResources(text, profile, constraints, valueSetLibrary, messageId);
                    // ValidateWithResourcesTextBox.Text = client.validateWithResources(text, profile, constraints, valueSetLibrary, messageId);
             //   }
              //  catch (Exception ex)
              //  {
                   // StatusLabel1.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
              //  }

            }

            //this chunk below deals with uploading the valuesetlibrary.xml (in the markup code, I specify that this filedialog should prompt for a .XML file)
            if (FileUploadControl2.HasFile)
            {
               // try
             //   {
                    filename4 = Path.GetFileName(FileUploadControl2.FileName);
                    FileUploadControl2.SaveAs(Server.MapPath("~/UploadValueSetLibrary/") + filename4);
                   // StatusLabel2.Text = "Upload status: File uploaded!";
                    WebServiceAggregator.valueSetLibrary1 = System.IO.File.ReadAllText(@"C:\Users\Owner\source\repos\HL7ClientProject\HL7ClientProject\UploadValueSetLibrary\" + filename4);
                    // LblValidateWithResources.Text = client.validateWithResources(text, profile, constraints, valueSetLibrary, messageId);
                    // ValidateWithResourcesTextBox.Text = client.validateWithResources(message1, profile, constraints, valueSetLibrary, messageId);
                   // ValidateWithResourcesTextBox.Text = client.validateWithResources(WebServiceAggregator.message1, WebServiceAggregator.profile1, WebServiceAggregator.constraints1, WebServiceAggregator.valueSetLibrary1, WebServiceAggregator.messageId1);
             ////   }
              //  catch (Exception ex)
              //  {
                  //  StatusLabel2.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
              //  }

            }

            //This code below checks for the correct extension in the filename. If the filename is still empty as we declared at top, it is missing.

           if ((!(filename1.Contains(".txt"))))
           {
              Response.Write("<script>alert('ERROR: Your Message input does not exist or uses the incorrect extention, should be .TXT. Please try again.')</script>");
           }

           if  (!(filename2.Contains(".xml"))){

                Response.Write("<script>alert('ERROR: Your Profile input does not exist or uses the incorrect extention, should be .XML. Please try again.')</script>");

            }

            if (!(filename3.Contains(".xml")))
            {

                Response.Write("<script>alert('ERROR: Your Constraints input does not exist or uses the incorrect extention, should be .XML. Please try again.')</script>");

            }

            if (!(filename4.Contains(".xml")))
            {

                Response.Write("<script>alert('ERROR: Your Value Set Library input does not exist or uses the incorrect extention, should be .XML. Please try again.')</script>");

            }



            //if all required items have been uploaded
            if (FileUploadControl.HasFile && FileUploadControl0.HasFile && FileUploadControl1.HasFile && FileUploadControl2.HasFile)
            {
                try
                {
                    //then display the report generated from validateWithResources in the text box. Notice we use message ID at the end which we grabbed in our profile upload code above

                    ValidateWithResourcesTextBox.Text = client.validateWithResources(WebServiceAggregator.message1, WebServiceAggregator.profile1, WebServiceAggregator.constraints1, WebServiceAggregator.valueSetLibrary1, WebServiceAggregator.messageId1);
                    // ValidateWithResourcesTextBox.Text = client.validateWithResources(WebServiceAggregator.message1, WebServiceAggregator.profile1, WebServiceAggregator.constraints1, WebServiceAggregator.valueSetLibrary1, messageId);
               
                    //This code below is what grabs the counts from the json and displays them

                    var myJsonString = client.validateWithResources(WebServiceAggregator.message1, WebServiceAggregator.profile1, WebServiceAggregator.constraints1, WebServiceAggregator.valueSetLibrary1, WebServiceAggregator.messageId1);
                    var jo = JObject.Parse(myJsonString);
                    var errors = jo["metaData"]["counts"]["error"].ToString();
                    var warnings = jo["metaData"]["counts"]["warning"].ToString();
                    var affirmatives = jo["metaData"]["counts"]["affirmative"].ToString();

                    Label11.Text = "Report Counts: " + "Errors - " + errors + " | Warnings - " + warnings + " | Affirmatives - " + affirmatives;

                }
                catch (Exception)
                {
                    Response.Write("<script>alert('ERROR: One or more of your files has the incorrect content. Please try again.')</script>");
                }

            }
            
            //otherwise display this error pop up message
            else
            {
                Response.Write("<script>alert('ERROR: You have not uploaded all files to generate a report. Please try again.')</script>");
            }
        }





        //this below is the save button and its contents
        protected void Button2_Click(object sender, EventArgs e)
        {
            string report = Convert.ToString(ValidateWithResourcesTextBox.Text);

            //StreamWriter File = new StreamWriter("Result.txt");
            //File.Write(report);
            //File.Close();

            System.IO.File.WriteAllText(Server.MapPath("~/Report/" + "report.json"), Request.Form[report]);
            string[] lines = {report};
            // WriteAllLines creates a file, writes a collection of strings to the file,
            // and then closes the file.  You do NOT need to call Flush() or Close().
            System.IO.File.WriteAllLines(@"C:\Users\Owner\source\repos\HL7ClientProject\HL7ClientProject\Report\report.json" , lines);

            //if the created json file is not empty (meaning they didn't upload all required items)
            if (new FileInfo(@"C:\Users\Owner\source\repos\HL7ClientProject\HL7ClientProject\Report\report.json").Length == 2)
            {
                //then present this error pop up

                // Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('*You haven't completed all uploads and generated a result, therefore there is nothing to save*');</script>");
                Response.Write("<script>alert('ERROR: You have not uploaded all files to generate a report to save. Please try again.')</script>");
            }

            //otherwise have them save it to their pc as a json file
            else
            {

                FileStream sourceFile = new FileStream(Server.MapPath("~/Report/" + "report.json"), FileMode.Open);
                float FileSize;
                FileSize = sourceFile.Length;
                byte[] fileContent = new byte[(int)FileSize];
                sourceFile.Read(fileContent, 0, (int)sourceFile.Length);
                sourceFile.Close();
                Response.ClearContent();
                Response.ClearHeaders();
                Response.Buffer = true;
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Length", fileContent.Length.ToString());
                Response.AddHeader("Content-Disposition", "attachment; filename=" + "REPORT.json");
                Response.BinaryWrite(fileContent);
                Response.Flush();
                Response.End();
            }
        }


    }

    }
