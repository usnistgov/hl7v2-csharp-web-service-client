<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebServiceAggregator.aspx.cs" Inherits="HL7ClientProject.WebServiceAggregator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color:#FFFFE0;">
    <form id="form1" runat="server" enctype="multipart/form-data">
    <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Image runat="server" ImageURL="~/Images/ClientImageTitle.png"></asp:Image>
            <br />
        <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Get Service Status" Width="231px" />
        <br />
        <br />
                <asp:TextBox ID="TextBox2" runat="server" Height="232px" TextMode="MultiLine" ValidateRequestMode="Disabled" Width="697px" BackColor="#F8F8F8" style="margin-top: 0px"></asp:TextBox>
        <br />
            <br />
        <p>
            <asp:Label ID="LblMessage" runat="server" Text="Required Message Validation Parameters" Font-Bold="True" Font-Underline="True" ForeColor="#000099"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Label ID="Label5" runat="server" Text="Profile (.XML):" Font-Bold="True" ForeColor="#000099"></asp:Label>
            <asp:FileUpload id="FileUploadControl0" runat="server" accept=".xml" BackColor="LightYellow" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
        <p>
            <asp:Label ID="Label6" runat="server" Text="Constraints (.XML):" Font-Bold="True" ForeColor="#000099"></asp:Label>
            <asp:FileUpload id="FileUploadControl1" runat="server" accept=".xml" BackColor="LightYellow" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
        <p>
            <asp:Label ID="Label7" runat="server" Text="Value Set Library (.XML):" Font-Bold="True" ForeColor="#000099"></asp:Label>
            <asp:FileUpload id="FileUploadControl2" runat="server" accept=".xml" BackColor="LightYellow" style="margin-bottom: 0px" />
        &nbsp;
        </p>
        <p>
            <asp:Label ID="Label4" runat="server" Text="Message (.TXT):" Font-Bold="True" ForeColor="#000099"></asp:Label>
            <asp:FileUpload id="FileUploadControl" runat="server" accept=".txt" BackColor="LightYellow" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
        <p>
            &nbsp;</p>
        <p>
    <asp:Button runat="server" id="UploadButton" text="Validate Message" onclick="UploadButton_Click" Width="345px" />
        &nbsp;&nbsp;
            <asp:Label ID="Label9" runat="server" Font-Bold="True" ForeColor="#000099" Text="Method: validateWithResources()"></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Message Validation Below:" Font-Bold="True" ForeColor="#000099"></asp:Label>
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Save Result" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </p>
        <p>
                <asp:TextBox ID="ValidateWithResourcesTextBox" runat="server" Height="222px" TextMode="MultiLine" Width="783px" BackColor="#F8F8F8"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label11" runat="server" Font-Bold="True" ForeColor="#000099" Text="Report Counts:"></asp:Label>
        </p>
        <p>
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Example Validation with Resources" Width="391px" />
            <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Italic="True" ForeColor="#000099" Text="*Initially Displays Message to Validate*"></asp:Label>
        &nbsp;
            <asp:Label runat="server" Font-Bold="True" ForeColor="#000099" Text="| Profile: VXU Z22 | Method: validateWithResources()"></asp:Label>
&nbsp;
        </p>
        <p>
        <asp:TextBox ID="TextBox1" runat="server" Height="300px" style="margin-bottom: 0px" TextMode="MultiLine" Width="707px" BackColor="#F8F8F8" >MSH|^~\&amp;|Test EHR Application|X68||NIST Test Iz Reg|20120701082240-0500||VXU^V04^VXU_V04|NIST-IZ-001.00|P|2.5.1|||ER|AL|||||Z22^CDCPHINVS
PID|1||D26376273^^^NIST MPI^MR||Snow^Madelynn^Ainsley^^^^L|Lam^Morgan^^^^^M|20070706|F||2076-8^Native Hawaiian or Other Pacific Islander^CDCREC|32 Prescott Street Ave^^Warwick^MA^02452^USA^L||^PRN^PH^^^657^5558563|||||||||2186-5^non Hispanic or Latino^CDCREC
PD1|||||||||||02^Reminder/Recall - any method^HL70215|||||A|20120701|20120701
NK1|1|Lam^Morgan^^^^^L|MTH^Mother^HL70063|32 Prescott Street Ave^^Warwick^MA^02452^USA^L|^PRN^PH^^^657^5558563
ORC|RE||IZ-783274^NDA|||||||I-23432^Burden^Donna^A^^^^^NIST-AA-1^^^^PRN||57422^RADON^NICHOLAS^^^^^^NIST-AA-1^L^^^MD
RXA|0|1|20120814||33332-0010-01^Influenza, seasonal, injectable, preservative free^NDC|0.5|mL^MilliLiter [SI Volume Units]^UCUM||00^New immunization record^NIP001|7832-1^Lemon^Mike^A^^^^^NIST-AA-1^^^^PRN|^^^X68||||Z0860BB|20121104|CSL^CSL Behring^MVX|||CP|A
RXR|C28161^Intramuscular^NCIT|LD^Left Arm^HL70163
OBX|1|CE|64994-7^Vaccine funding program eligibility category^LN|1|V05^VFC eligible - Federally Qualified Health Center Patient (under-insured)^HL70064||||||F|||20120701|||VXC40^Eligibility captured at the immunization level^CDCPHINVS
OBX|2|CE|30956-7^vaccine type^LN|2|88^Influenza, unspecified formulation^CVX||||||F
OBX|3|TS|29768-9^Date vaccine information statement published^LN|2|20120702||||||F
OBX|4|TS|29769-7^Date vaccine information statement presented^LN|2|20120814||||||F</asp:TextBox>
        </p>
    <p>
        <asp:Label ID="Label10" runat="server" Font-Bold="True" ForeColor="#000099" Text="Report Counts:"></asp:Label>
        </p>
    </form>
    </body>
</html>
