using System;
using System.Management.Automation;
using Azure.Identity;
using Azure.Core;


namespace myModule
{
    [Cmdlet(VerbsDiagnostic.Test,"SampleCmdlet")]
    [OutputType(typeof(string))]
    public class TestSampleCmdletCommand : PSCmdlet
    {

        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
            WriteVerbose("Begin!");
        }

        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessRecord()
        {
            WriteVerbose("Process");
            var Cred = new ManagedIdentityCredential();
            var Scope = new String[] { $"https://management.azure.com" };
            var Request = new TokenRequestContext(Scope);
            var Token = Cred.GetToken(Request);
            WriteObject(Token.Token);            
        }

        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
            WriteVerbose("End!");
        }
    }

}
