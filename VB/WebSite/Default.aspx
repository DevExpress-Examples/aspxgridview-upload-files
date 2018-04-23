<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>

</head>
<body>
	<form id="form1" runat="server">
		<div>
			<dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" OnDataBound="ASPxGridView1_DataBound" DataSourceID="SqlDataSource1" KeyFieldName="ProductID" OnCustomUnboundColumnData="ASPxGridView1_CustomUnboundColumnData">
				<Columns>
					<dx:GridViewCommandColumn VisibleIndex="0">
						<EditButton Visible="True">
						</EditButton>
					</dx:GridViewCommandColumn>
					<dx:GridViewDataTextColumn FieldName="ProductID" ReadOnly="True" VisibleIndex="1">
						<EditFormSettings Visible="False" />
					</dx:GridViewDataTextColumn>
					<dx:GridViewDataTextColumn FieldName="ProductName" VisibleIndex="2">
					</dx:GridViewDataTextColumn>
					<dx:GridViewDataComboBoxColumn Settings-AllowAutoFilter="True" FieldName="CategoryID" VisibleIndex="3">
						<Settings ShowFilterRowMenu="True" AllowHeaderFilter="True" FilterMode="DisplayText" />
						<PropertiesComboBox TextField="CategoryName" DataSourceID="SqlDataSource2" ValueField="CategoryID" ValueType="System.Int32">
						</PropertiesComboBox>
					</dx:GridViewDataComboBoxColumn>
					<dx:GridViewDataTextColumn FieldName="UnitPrice" VisibleIndex="4">
					</dx:GridViewDataTextColumn>
					<dx:GridViewDataCheckColumn FieldName="Discontinued" VisibleIndex="5">
					</dx:GridViewDataCheckColumn>
					<dx:GridViewDataTextColumn FieldName="Url" UnboundType="Object" VisibleIndex="6">
						<EditFormCaptionStyle VerticalAlign="Top">
						</EditFormCaptionStyle>
						<DataItemTemplate>
							<dx:ASPxHyperLink ID="ASPxHyperLink" OnLoad="ASPxHyperLink_Load" runat="server" Target="_blank" Text="null ref">
							</dx:ASPxHyperLink>
						</DataItemTemplate>
						<EditItemTemplate>
							<dx:ASPxUploadControl ID="ASPxUploadControl1" ShowProgressPanel="true" FileUploadMode="OnPageLoad" OnFileUploadComplete="ASPxUploadControl1_FileUploadComplete" runat="server" Width="280px" AddUploadButtonsHorizontalPosition="Center" ShowUploadButton="True">
								<ValidationSettings MaxFileSize="4194304"   MaxFileSizeErrorText="Size of the uploaded file exceeds maximum file size"  AllowedFileExtensions=".jpg,.jpeg,.jpe,.gif,.pdf">
								</ValidationSettings>
							</dx:ASPxUploadControl>
							<dx:ASPxLabel ID="lblAllowebMimeType" runat="server" Text="Allowed image types: jpeg, gif, pdf"
								Font-Size="8pt">
							</dx:ASPxLabel>
							<br />
							<dx:ASPxLabel ID="lblMaxFileSize" runat="server" Text="Maximum file size: 4Mb" Font-Size="8pt"></dx:ASPxLabel>
						</EditItemTemplate>
					</dx:GridViewDataTextColumn>
				</Columns>

				<Settings ShowFilterRow="True" ShowFilterRowMenu="True"></Settings>
			</dx:ASPxGridView>

			<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>" SelectCommand="SELECT [ProductID], [ProductName], [CategoryID], [UnitPrice], [Discontinued] FROM [Products]" DeleteCommand="DELETE FROM [Products] WHERE [ProductID] = @ProductID" InsertCommand="INSERT INTO [Products] ([ProductName], [CategoryID], [UnitPrice], [Discontinued]) VALUES (@ProductName, @CategoryID, @UnitPrice, @Discontinued)" UpdateCommand="UPDATE [Products] SET [ProductName] = @ProductName, [CategoryID] = @CategoryID, [UnitPrice] = @UnitPrice, [Discontinued] = @Discontinued WHERE [ProductID] = @ProductID">
				<DeleteParameters>
					<asp:Parameter Name="ProductID" Type="Int32" />
				</DeleteParameters>
				<InsertParameters>
					<asp:Parameter Name="ProductName" Type="String" />
					<asp:Parameter Name="CategoryID" Type="Int32" />
					<asp:Parameter Name="UnitPrice" Type="Decimal" />
					<asp:Parameter Name="Discontinued" Type="Boolean" />
				</InsertParameters>
				<UpdateParameters>
					<asp:Parameter Name="ProductName" Type="String" />
					<asp:Parameter Name="CategoryID" Type="Int32" />
					<asp:Parameter Name="UnitPrice" Type="Decimal" />
					<asp:Parameter Name="Discontinued" Type="Boolean" />
					<asp:Parameter Name="ProductID" Type="Int32" />
				</UpdateParameters>
			</asp:SqlDataSource>
			<asp:SqlDataSource ID="SqlDataSource2" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>" SelectCommand="SELECT * FROM [Categories]" runat="server"></asp:SqlDataSource>
			<dx:ASPxButton ID="ASPxButton1" runat="server" AutoPostBack="true" Text="PostBack" Theme="Aqua">
			</dx:ASPxButton>
			<br />
		</div>
	</form>
</body>
</html>