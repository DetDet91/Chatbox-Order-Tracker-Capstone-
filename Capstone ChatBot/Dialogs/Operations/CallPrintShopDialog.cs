using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

//Code when they press on the Call print shop button

namespace Capstone_ChatBot.Dialogs.Operations
{
    public class CallPrintShopDialog : ComponentDialog
    {
        public CallPrintShopDialog(): base(nameof(CallPrintShopDialog))
        {
            var waterfallSteps = new WaterfallStep[]
            {
                GetPhoneNumberStepAsync,
                PrintPhoneNumberStepAsync
            };

            AddDialog(new WaterfallDialog(nameof(WaterfallDialog), waterfallSteps));
            AddDialog(new TextPrompt(nameof(TextPrompt)));

            InitialDialogId = nameof(WaterfallDialog);
        }
        //Fetch the print shop number
        private async Task<DialogTurnResult>GetPhoneNumberStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            String phoneNumber = "(843)777-2979";

            return await stepContext.NextAsync(phoneNumber, cancellationToken);
        }
        //Print out of it
        private async Task<DialogTurnResult>PrintPhoneNumberStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            String phoneNumber = (string)stepContext.Result;

            await stepContext.Context.SendActivityAsync($"The phone number for the Print Shop is {phoneNumber} ask for Destiny or Lorretta");

            return await stepContext.EndDialogAsync(null, cancellationToken);
        }
    }
}
