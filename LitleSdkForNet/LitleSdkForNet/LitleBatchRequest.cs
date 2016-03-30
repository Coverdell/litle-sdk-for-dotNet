using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Text;
using Litle.Sdk.Properties;

namespace Litle.Sdk
{
    public class batchRequest
    {
        public string id;
        public string merchantId;
        public string reportGroup;

        public Dictionary<string, string> config;
        private readonly IDictionary<string, StringBuilder> _cache;

        public string batchFilePath;
        private string _tempBatchFilePath;
        private litleFile _litleFile;
        private litleTime _litleTime;
        private string _requestDirectory;
        private string _responseDirectory;

        private int _numAuthorization;
        private int _numAccountUpdates;
        private int _numCapture;
        private int _numCredit;
        private int _numSale;
        private int _numAuthReversal;
        private int _numEcheckCredit;
        private int _numEcheckVerification;
        private int _numEcheckSale;
        private int _numRegisterTokenRequest;
        private int _numForceCapture;
        private int _numCaptureGivenAuth;
        private int _numEcheckRedeposit;
        private int _numEcheckPreNoteSale;
        private int _numEcheckPreNoteCredit;
        private int _numUpdateCardValidationNumOnToken;
        private int _numUpdateSubscriptions;
        private int _numCancelSubscriptions;
        private int _numCreatePlans;
        private int _numUpdatePlans;
        private int _numActivates;
        private int _numDeactivates;
        private int _numLoads;
        private int _numUnloads;
        private int _numBalanceInquiries;
        private int _numPayFacCredit;
        private int _numSubmerchantCredit;
        private int _numReserveCredit;
        private int _numVendorCredit;
        private int _numPhysicalCheckCredit;
        private int _numPayFacDebit;
        private int _numSubmerchantDebit;
        private int _numReserveDebit;
        private int _numVendorDebit;
        private int _numPhysicalCheckDebit;

        private long _sumOfAuthorization;
        private long _sumOfAuthReversal;
        private long _sumOfCapture;
        private long _sumOfCredit;
        private long _sumOfSale;
        private long _sumOfForceCapture;
        private long _sumOfEcheckSale;
        private long _sumOfEcheckCredit;
        private long _sumOfEcheckVerification;
        private long _sumOfCaptureGivenAuth;
        private long _activateAmount;
        private long _loadAmount;
        private long _unloadAmount;
        private long _payFacCreditAmount;
        private long _submerchantCreditAmount;
        private long _reserveCreditAmount;
        private long _vendorCreditAmount;
        private long _physicalCheckCreditAmount;
        private long _payFacDebitAmount;
        private long _submerchantDebitAmount;
        private long _reserveDebitAmount;
        private long _vendorDebitAmount;
        private long _physicalCheckDebitAmount;

        private const string AccountUpdateErrorMessage = "Account Updates need to exist in their own batch request!";

        public batchRequest(IDictionary<string, StringBuilder> cache)
        {
            _cache = cache;
            config = new Dictionary<string, string>
            {
                ["url"] = Settings.Default.url,
                ["reportGroup"] = Settings.Default.reportGroup,
                ["username"] = Settings.Default.username,
                ["printxml"] = Settings.Default.printxml,
                ["timeout"] = Settings.Default.timeout,
                ["proxyHost"] = Settings.Default.proxyHost,
                ["merchantId"] = Settings.Default.merchantId,
                ["password"] = Settings.Default.password,
                ["proxyPort"] = Settings.Default.proxyPort,
                ["sftpUrl"] = Settings.Default.sftpUrl,
                ["sftpUsername"] = Settings.Default.sftpUsername,
                ["sftpPassword"] = Settings.Default.sftpPassword,
                ["knownHostsFile"] = Settings.Default.knownHostsFile,
                ["requestDirectory"] = Settings.Default.requestDirectory,
                ["responseDirectory"] = Settings.Default.responseDirectory
            };

            InitializeRequest();
        }

        public batchRequest(IDictionary<string, StringBuilder> cache, Dictionary<string, string> config)
        {
            _cache = cache;
            this.config = config;

            InitializeRequest();
        }

        private void InitializeRequest()
        {
            _requestDirectory = config["requestDirectory"] + "\\Requests\\";
            _responseDirectory = config["responseDirectory"] + "\\Responses\\";

            _litleFile = new litleFile(_cache);
            _litleTime = new litleTime();

            _numAuthorization = 0;
            _numAuthReversal = 0;
            _numCapture = 0;
            _numCaptureGivenAuth = 0;
            _numCredit = 0;
            _numEcheckCredit = 0;
            _numEcheckRedeposit = 0;
            _numEcheckPreNoteSale = 0;
            _numEcheckPreNoteCredit = 0;
            _numEcheckSale = 0;
            _numEcheckVerification = 0;
            _numForceCapture = 0;
            _numRegisterTokenRequest = 0;
            _numSale = 0;
            _numUpdateCardValidationNumOnToken = 0;
            _numUpdateSubscriptions = 0;
            _numCancelSubscriptions = 0;
            _numPayFacCredit = 0;
            _numSubmerchantCredit = 0;
            _numReserveCredit = 0;
            _numVendorCredit = 0;
            _numPhysicalCheckCredit = 0;
            _numPayFacDebit = 0;
            _numSubmerchantDebit = 0;
            _numReserveDebit = 0;
            _numVendorDebit = 0;
            _numPhysicalCheckDebit = 0;

            _sumOfAuthorization = 0;
            _sumOfAuthReversal = 0;
            _sumOfCapture = 0;
            _sumOfCredit = 0;
            _sumOfSale = 0;
            _sumOfForceCapture = 0;
            _sumOfEcheckSale = 0;
            _sumOfEcheckCredit = 0;
            _sumOfEcheckVerification = 0;
            _sumOfCaptureGivenAuth = 0;
            _payFacCreditAmount = 0;
            _submerchantCreditAmount = 0;
            _reserveCreditAmount = 0;
            _vendorCreditAmount = 0;
            _physicalCheckCreditAmount = 0;
            _payFacDebitAmount = 0;
            _submerchantDebitAmount = 0;
            _reserveDebitAmount = 0;
            _vendorDebitAmount = 0;
            _physicalCheckDebitAmount = 0;
        }

        public string getResponseDirectory() => _responseDirectory;

        public string getRequestDirectory() => _requestDirectory;

        public void setLitleFile(litleFile litleFile) => _litleFile = litleFile;

        public litleFile getLitleFile() => _litleFile;

        public void setLitleTime(litleTime litleTime) => _litleTime = litleTime;

        public litleTime getLitleTime() => _litleTime;

        public int getNumAuthorization() => _numAuthorization;

        public int getNumAccountUpdates() => _numAccountUpdates;

        public int getNumCapture() => _numCapture;

        public int getNumCredit() => _numCredit;

        public int getNumSale() => _numSale;

        public int getNumAuthReversal() => _numAuthReversal;

        public int getNumEcheckCredit() => _numEcheckCredit;

        public int getNumEcheckVerification() => _numEcheckVerification;

        public int getNumEcheckSale() => _numEcheckSale;

        public int getNumRegisterTokenRequest() => _numRegisterTokenRequest;

        public int getNumForceCapture() => _numForceCapture;

        public int getNumCaptureGivenAuth() => _numCaptureGivenAuth;

        public int getNumEcheckRedeposit() => _numEcheckRedeposit;

        public int getNumEcheckPreNoteSale() => _numEcheckPreNoteSale;

        public int getNumEcheckPreNoteCredit() => _numEcheckPreNoteCredit;

        public int getNumUpdateCardValidationNumOnToken() => _numUpdateCardValidationNumOnToken;

        public int getNumUpdateSubscriptions() => _numUpdateSubscriptions;

        public int getNumCancelSubscriptions() => _numCancelSubscriptions;

        public int getNumCreatePlans() => _numCreatePlans;

        public int getNumUpdatePlans() => _numUpdatePlans;

        public int getNumActivates() => _numActivates;

        public int getNumDeactivates() => _numDeactivates;

        public int getNumLoads() => _numLoads;

        public int getNumUnloads() => _numUnloads;

        public int getNumBalanceInquiries() => _numBalanceInquiries;

        public int getNumPayFacCredit() => _numPayFacCredit;

        public int getNumSubmerchantCredit() => _numSubmerchantCredit;

        public int getNumReserveCredit() => _numReserveCredit;

        public int getNumVendorCredit() => _numVendorCredit;

        public int getNumPhysicalCheckCredit() => _numPhysicalCheckCredit;

        public int getNumPayFacDebit() => _numPayFacDebit;

        public int getNumSubmerchantDebit() => _numSubmerchantDebit;

        public int getNumReserveDebit() => _numReserveDebit;

        public int getNumVendorDebit() => _numVendorDebit;

        public int getNumPhysicalCheckDebit() => _numPhysicalCheckDebit;

        public long getLoadAmount() => _loadAmount;

        public long getUnloadAmount() => _unloadAmount;

        public long getActivateAmount() => _activateAmount;

        public long getSumOfAuthorization() => _sumOfAuthorization;

        public long getSumOfAuthReversal() => _sumOfAuthReversal;

        public long getSumOfCapture() => _sumOfCapture;

        public long getSumOfCredit() => _sumOfCredit;

        public long getSumOfSale() => _sumOfSale;

        public long getSumOfForceCapture() => _sumOfForceCapture;

        public long getSumOfEcheckSale() => _sumOfEcheckSale;

        public long getSumOfEcheckCredit() => _sumOfEcheckCredit;

        public long getSumOfEcheckVerification() => _sumOfEcheckVerification;

        public long getSumOfCaptureGivenAuth() => _sumOfCaptureGivenAuth;

        public long getPayFacCreditAmount() => _payFacCreditAmount;

        public long getSubmerchantCreditAmount() => _submerchantCreditAmount;

        public long getReserveCreditAmount() => _reserveCreditAmount;

        public long getVendorCreditAmount() => _vendorCreditAmount;

        public long getPhysicalCheckCreditAmount() => _physicalCheckCreditAmount;

        public long getPayFacDebitAmount() => _payFacDebitAmount;

        public long getSubmerchantDebitAmount() => _submerchantDebitAmount;

        public long getReserveDebitAmount() => _reserveDebitAmount;

        public long getVendorDebitAmount() => _vendorDebitAmount;

        public long getPhysicalCheckDebitAmount() => _physicalCheckDebitAmount;

        public void addAuthorization(authorization authorization)
        {
            if (_numAccountUpdates == 0)
            {
                _numAuthorization++;
                _sumOfAuthorization += authorization.amount;
                FillInReportGroup(authorization);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, authorization);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void addCapture(capture capture)
        {
            if (_numAccountUpdates == 0)
            {
                _numCapture++;
                _sumOfCapture += capture.amount;
                FillInReportGroup(capture);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, capture);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void addCredit(credit credit)
        {
            if (_numAccountUpdates == 0)
            {
                _numCredit++;
                _sumOfCredit += credit.amount;
                FillInReportGroup(credit);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, credit);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void addSale(sale sale)
        {
            if (_numAccountUpdates == 0)
            {
                _numSale++;
                _sumOfSale += sale.amount;
                FillInReportGroup(sale);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, sale);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void addAuthReversal(authReversal authReversal)
        {
            if (_numAccountUpdates == 0)
            {
                _numAuthReversal++;
                _sumOfAuthReversal += authReversal.amount;
                FillInReportGroup(authReversal);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, authReversal);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void addEcheckCredit(echeckCredit echeckCredit)
        {
            if (_numAccountUpdates == 0)
            {
                _numEcheckCredit++;
                _sumOfEcheckCredit += echeckCredit.amount;
                FillInReportGroup(echeckCredit);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, echeckCredit);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void addEcheckVerification(echeckVerification echeckVerification)
        {
            if (_numAccountUpdates == 0)
            {
                _numEcheckVerification++;
                _sumOfEcheckVerification += echeckVerification.amount;
                FillInReportGroup(echeckVerification);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, echeckVerification);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void addEcheckSale(echeckSale echeckSale)
        {
            if (_numAccountUpdates == 0)
            {
                _numEcheckSale++;
                _sumOfEcheckSale += echeckSale.amount;
                FillInReportGroup(echeckSale);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, echeckSale);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void addRegisterTokenRequest(registerTokenRequestType registerTokenRequestType)
        {
            if (_numAccountUpdates == 0)
            {
                _numRegisterTokenRequest++;
                FillInReportGroup(registerTokenRequestType);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, registerTokenRequestType);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void addForceCapture(forceCapture forceCapture)
        {
            if (_numAccountUpdates == 0)
            {
                _numForceCapture++;
                _sumOfForceCapture += forceCapture.amount;
                FillInReportGroup(forceCapture);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, forceCapture);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void addCaptureGivenAuth(captureGivenAuth captureGivenAuth)
        {
            if (_numAccountUpdates == 0)
            {
                _numCaptureGivenAuth++;
                _sumOfCaptureGivenAuth += captureGivenAuth.amount;
                FillInReportGroup(captureGivenAuth);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, captureGivenAuth);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void addEcheckRedeposit(echeckRedeposit echeckRedeposit)
        {
            if (_numAccountUpdates == 0)
            {
                _numEcheckRedeposit++;
                FillInReportGroup(echeckRedeposit);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, echeckRedeposit);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void addEcheckPreNoteSale(echeckPreNoteSale echeckPreNoteSale)
        {
            if (_numAccountUpdates == 0)
            {
                _numEcheckPreNoteSale++;
                FillInReportGroup(echeckPreNoteSale);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, echeckPreNoteSale);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void addEcheckPreNoteCredit(echeckPreNoteCredit echeckPreNoteCredit)
        {
            if (_numAccountUpdates == 0)
            {
                _numEcheckPreNoteCredit++;
                FillInReportGroup(echeckPreNoteCredit);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, echeckPreNoteCredit);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void addUpdateCardValidationNumOnToken(updateCardValidationNumOnToken updateCardValidationNumOnToken)
        {
            if (_numAccountUpdates == 0)
            {
                _numUpdateCardValidationNumOnToken++;
                FillInReportGroup(updateCardValidationNumOnToken);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, updateCardValidationNumOnToken);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void addUpdateSubscription(updateSubscription updateSubscription)
        {
            if (_numAccountUpdates == 0)
            {
                _numUpdateSubscriptions++;
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, updateSubscription);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void addCancelSubscription(cancelSubscription cancelSubscription)
        {
            if (_numAccountUpdates == 0)
            {
                _numCancelSubscriptions++;
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, cancelSubscription);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void addCreatePlan(createPlan createPlan)
        {
            if (_numAccountUpdates == 0)
            {
                _numCreatePlans++;
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, createPlan);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void addUpdatePlan(updatePlan updatePlan)
        {
            if (_numAccountUpdates == 0)
            {
                _numUpdatePlans++;
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, updatePlan);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void addActivate(activate activate)
        {
            if (_numAccountUpdates == 0)
            {
                _numActivates++;
                _activateAmount += activate.amount;
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, activate);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void addDeactivate(deactivate deactivate)
        {
            if (_numAccountUpdates == 0)
            {
                _numDeactivates++;
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, deactivate);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void addLoad(load load)
        {
            if (_numAccountUpdates == 0)
            {
                _numLoads++;
                _loadAmount += load.amount;
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, load);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void addUnload(unload unload)
        {
            if (_numAccountUpdates == 0)
            {
                _numUnloads++;
                _unloadAmount += unload.amount;
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, unload);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void addBalanceInquiry(balanceInquiry balanceInquiry)
        {
            if (_numAccountUpdates == 0)
            {
                _numBalanceInquiries++;
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, balanceInquiry);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void addAccountUpdate(accountUpdate accountUpdate)
        {
            if (IsOnlyAccountUpdates())
            {
                _numAccountUpdates++;
                FillInReportGroup(accountUpdate);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, accountUpdate);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void addSubmerchantCredit(submerchantCredit submerchantCredit)
        {
            if (_numAccountUpdates == 0)
            {
                _numSubmerchantCredit++;
                _submerchantCreditAmount += (long) submerchantCredit.amount;
                FillInReportGroup(submerchantCredit);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, submerchantCredit);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void addPayFacCredit(payFacCredit payFacCredit)
        {
            if (_numAccountUpdates == 0)
            {
                _numPayFacCredit++;
                _payFacCreditAmount += (long) payFacCredit.amount;
                FillInReportGroup(payFacCredit);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, payFacCredit);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void addReserveCredit(reserveCredit reserveCredit)
        {
            if (_numAccountUpdates == 0)
            {
                _numReserveCredit++;
                _reserveCreditAmount += (long) reserveCredit.amount;
                FillInReportGroup(reserveCredit);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, reserveCredit);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void addVendorCredit(vendorCredit vendorCredit)
        {
            if (_numAccountUpdates == 0)
            {
                _numVendorCredit++;
                _vendorCreditAmount += (long) vendorCredit.amount;
                FillInReportGroup(vendorCredit);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, vendorCredit);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void addPhysicalCheckCredit(physicalCheckCredit physicalCheckCredit)
        {
            if (_numAccountUpdates == 0)
            {
                _numPhysicalCheckCredit++;
                _physicalCheckCreditAmount += (long) physicalCheckCredit.amount;
                FillInReportGroup(physicalCheckCredit);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, physicalCheckCredit);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void addSubmerchantDebit(submerchantDebit submerchantDebit)
        {
            if (_numAccountUpdates == 0)
            {
                _numSubmerchantDebit++;
                _submerchantDebitAmount += (long) submerchantDebit.amount;
                FillInReportGroup(submerchantDebit);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, submerchantDebit);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void addPayFacDebit(payFacDebit payFacDebit)
        {
            if (_numAccountUpdates == 0)
            {
                _numPayFacDebit++;
                _payFacDebitAmount += (long) payFacDebit.amount;
                FillInReportGroup(payFacDebit);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, payFacDebit);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void addReserveDebit(reserveDebit reserveDebit)
        {
            if (_numAccountUpdates == 0)
            {
                _numReserveDebit++;
                _reserveDebitAmount += (long) reserveDebit.amount;
                FillInReportGroup(reserveDebit);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, reserveDebit);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void addVendorDebit(vendorDebit vendorDebit)
        {
            if (_numAccountUpdates == 0)
            {
                _numVendorDebit++;
                _vendorDebitAmount += (long) vendorDebit.amount;
                FillInReportGroup(vendorDebit);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, vendorDebit);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public void addPhysicalCheckDebit(physicalCheckDebit physicalCheckDebit)
        {
            if (_numAccountUpdates == 0)
            {
                _numPhysicalCheckDebit++;
                _physicalCheckDebitAmount += (long) physicalCheckDebit.amount;
                FillInReportGroup(physicalCheckDebit);
                _tempBatchFilePath = SaveElement(_litleFile, _litleTime, _tempBatchFilePath, physicalCheckDebit);
            }
            else
            {
                throw new LitleOnlineException(AccountUpdateErrorMessage);
            }
        }

        public string Serialize()
        {
            var xmlHeader = generateXmlHeader();

            const string xmlFooter = "</batchRequest>\r\n";

            batchFilePath = _litleFile.createRandomFile(_requestDirectory, null, "_batchRequest.xml", _litleTime);

            _litleFile.AppendLineToFile(batchFilePath, xmlHeader);
            _litleFile.AppendFileToFile(batchFilePath, _tempBatchFilePath);
            _litleFile.AppendLineToFile(batchFilePath, xmlFooter);
            
            return batchFilePath;
        }

        public string generateXmlHeader()
        {
            var xmlHeader = "\r\n<batchRequest id=\"" + id + "\"\r\n";

            if (_numAuthorization != 0)
            {
                xmlHeader += "numAuths=\"" + _numAuthorization + "\"\r\n";
                xmlHeader += "authAmount=\"" + _sumOfAuthorization + "\"\r\n";
            }

            if (_numAuthReversal != 0)
            {
                xmlHeader += "numAuthReversals=\"" + _numAuthReversal + "\"\r\n";
                xmlHeader += "authReversalAmount=\"" + _sumOfAuthReversal + "\"\r\n";
            }

            if (_numCapture != 0)
            {
                xmlHeader += "numCaptures=\"" + _numCapture + "\"\r\n";
                xmlHeader += "captureAmount=\"" + _sumOfCapture + "\"\r\n";
            }

            if (_numCredit != 0)
            {
                xmlHeader += "numCredits=\"" + _numCredit + "\"\r\n";
                xmlHeader += "creditAmount=\"" + _sumOfCredit + "\"\r\n";
            }

            if (_numForceCapture != 0)
            {
                xmlHeader += "numForceCaptures=\"" + _numForceCapture + "\"\r\n";
                xmlHeader += "forceCaptureAmount=\"" + _sumOfForceCapture + "\"\r\n";
            }

            if (_numSale != 0)
            {
                xmlHeader += "numSales=\"" + _numSale + "\"\r\n";
                xmlHeader += "saleAmount=\"" + _sumOfSale + "\"\r\n";
            }

            if (_numCaptureGivenAuth != 0)
            {
                xmlHeader += "numCaptureGivenAuths=\"" + _numCaptureGivenAuth + "\"\r\n";
                xmlHeader += "captureGivenAuthAmount=\"" + _sumOfCaptureGivenAuth + "\"\r\n";
            }

            if (_numEcheckSale != 0)
            {
                xmlHeader += "numEcheckSales=\"" + _numEcheckSale + "\"\r\n";
                xmlHeader += "echeckSalesAmount=\"" + _sumOfEcheckSale + "\"\r\n";
            }

            if (_numEcheckCredit != 0)
            {
                xmlHeader += "numEcheckCredit=\"" + _numEcheckCredit + "\"\r\n";
                xmlHeader += "echeckCreditAmount=\"" + _sumOfEcheckCredit + "\"\r\n";
            }

            if (_numEcheckVerification != 0)
            {
                xmlHeader += "numEcheckVerification=\"" + _numEcheckVerification + "\"\r\n";
                xmlHeader += "echeckVerificationAmount=\"" + _sumOfEcheckVerification + "\"\r\n";
            }

            if (_numEcheckRedeposit != 0)
            {
                xmlHeader += "numEcheckRedeposit=\"" + _numEcheckRedeposit + "\"\r\n";
            }

            if (_numEcheckPreNoteSale != 0)
            {
                xmlHeader += "numEcheckPreNoteSale=\"" + _numEcheckPreNoteSale + "\"\r\n";
            }

            if (_numEcheckPreNoteCredit != 0)
            {
                xmlHeader += "numEcheckPreNoteCredit=\"" + _numEcheckPreNoteCredit + "\"\r\n";
            }

            if (_numAccountUpdates != 0)
            {
                xmlHeader += "numAccountUpdates=\"" + _numAccountUpdates + "\"\r\n";
            }

            if (_numRegisterTokenRequest != 0)
            {
                xmlHeader += "numTokenRegistrations=\"" + _numRegisterTokenRequest + "\"\r\n";
            }

            if (_numUpdateCardValidationNumOnToken != 0)
            {
                xmlHeader += "numUpdateCardValidationNumOnTokens=\"" + _numUpdateCardValidationNumOnToken + "\"\r\n";
            }

            if (_numUpdateSubscriptions != 0)
            {
                xmlHeader += "numUpdateSubscriptions=\"" + _numUpdateSubscriptions + "\"\r\n";
            }

            if (_numCancelSubscriptions != 0)
            {
                xmlHeader += "numCancelSubscriptions=\"" + _numCancelSubscriptions + "\"\r\n";
            }

            if (_numCreatePlans != 0)
            {
                xmlHeader += "numCreatePlans=\"" + _numCreatePlans + "\"\r\n";
            }

            if (_numUpdatePlans != 0)
            {
                xmlHeader += "numUpdatePlans=\"" + _numUpdatePlans + "\"\r\n";
            }

            if (_numActivates != 0)
            {
                xmlHeader += "numUpdateActivates=\"" + _numActivates + "\"\r\n";
                xmlHeader += "activateAmount=\"" + _activateAmount + "\"\r\n";
            }

            if (_numDeactivates != 0)
            {
                xmlHeader += "numDeactivates=\"" + _numDeactivates + "\"\r\n";
            }

            if (_numLoads != 0)
            {
                xmlHeader += "numLoads=\"" + _numLoads + "\"\r\n";
                xmlHeader += "loadAmount=\"" + _loadAmount + "\"\r\n";
            }

            if (_numUnloads != 0)
            {
                xmlHeader += "numUnloads=\"" + _numUnloads + "\"\r\n";
                xmlHeader += "unloadAmount=\"" + _unloadAmount + "\"\r\n";
            }

            if (_numBalanceInquiries != 0)
            {
                xmlHeader += "numBalanceInquirys=\"" + _numBalanceInquiries + "\"\r\n";
            }

            if (_numPayFacCredit != 0)
            {
                xmlHeader += "numPayFacCredit=\"" + _numPayFacCredit + "\"\r\n";
                xmlHeader += "payFacCreditAmount=\"" + _payFacCreditAmount + "\"\r\n";
            }

            if (_numSubmerchantCredit != 0)
            {
                xmlHeader += "numSubmerchantCredit=\"" + _numSubmerchantCredit + "\"\r\n";
                xmlHeader += "submerchantCreditAmount=\"" + _submerchantCreditAmount + "\"\r\n";
            }

            if (_numReserveCredit != 0)
            {
                xmlHeader += "numReserveCredit=\"" + _numReserveCredit + "\"\r\n";
                xmlHeader += "reserveCreditAmount=\"" + _reserveCreditAmount + "\"\r\n";
            }

            if (_numVendorCredit != 0)
            {
                xmlHeader += "numVendorCredit=\"" + _numVendorCredit + "\"\r\n";
                xmlHeader += "vendorCreditAmount=\"" + _vendorCreditAmount + "\"\r\n";
            }

            if (_numPhysicalCheckCredit != 0)
            {
                xmlHeader += "numPhysicalCheckCredit=\"" + _numPhysicalCheckCredit + "\"\r\n";
                xmlHeader += "physicalCheckCreditAmount=\"" + _physicalCheckCreditAmount + "\"\r\n";
            }

            if (_numPayFacDebit != 0)
            {
                xmlHeader += "numPayFacDebit=\"" + _numPayFacDebit + "\"\r\n";
                xmlHeader += "payFacDebitAmount=\"" + _payFacDebitAmount + "\"\r\n";
            }

            if (_numSubmerchantDebit != 0)
            {
                xmlHeader += "numSubmerchantDebit=\"" + _numSubmerchantDebit + "\"\r\n";
                xmlHeader += "submerchantDebitAmount=\"" + _submerchantDebitAmount + "\"\r\n";
            }

            if (_numReserveDebit != 0)
            {
                xmlHeader += "numReserveDebit=\"" + _numReserveDebit + "\"\r\n";
                xmlHeader += "reserveDebitAmount=\"" + _reserveDebitAmount + "\"\r\n";
            }

            if (_numVendorDebit != 0)
            {
                xmlHeader += "numVendorDebit=\"" + _numVendorDebit + "\"\r\n";
                xmlHeader += "vendorDebitAmount=\"" + _vendorDebitAmount + "\"\r\n";
            }

            if (_numPhysicalCheckDebit != 0)
            {
                xmlHeader += "numPhysicalCheckDebit=\"" + _numPhysicalCheckDebit + "\"\r\n";
                xmlHeader += "physicalCheckDebitAmount=\"" + _physicalCheckDebitAmount + "\"\r\n";
            }

            xmlHeader += "merchantSdk=\"DotNet;9.3.2\"\r\n";

            xmlHeader += "merchantId=\"" + config["merchantId"] + "\">\r\n";
            return xmlHeader;
        }

        private string SaveElement(litleFile litleFile, litleTime litleTime, string filePath, transactionRequest element)
        {
            var fPath = litleFile.createRandomFile(_requestDirectory, Path.GetFileName(filePath), "_temp_batchRequest.xml",
                litleTime);

            litleFile.AppendLineToFile(fPath, element.Serialize());

            return fPath;
        }

        private void FillInReportGroup(transactionTypeWithReportGroup txn)
        {
            if (txn.reportGroup == null)
            {
                txn.reportGroup = config["reportGroup"];
            }
        }

        private void FillInReportGroup(transactionTypeWithReportGroupAndPartial txn)
        {
            if (txn.reportGroup == null)
            {
                txn.reportGroup = config["reportGroup"];
            }
        }

        private bool IsOnlyAccountUpdates() => _numAuthorization == 0
                                               && _numCapture == 0
                                               && _numCredit == 0
                                               && _numSale == 0
                                               && _numAuthReversal == 0
                                               && _numEcheckCredit == 0
                                               && _numEcheckVerification == 0
                                               && _numEcheckSale == 0
                                               && _numRegisterTokenRequest == 0
                                               && _numForceCapture == 0
                                               && _numCaptureGivenAuth == 0
                                               && _numEcheckRedeposit == 0
                                               && _numEcheckPreNoteSale == 0
                                               && _numEcheckPreNoteCredit == 0
                                               && _numUpdateCardValidationNumOnToken == 0
                                               && _numUpdateSubscriptions == 0
                                               && _numCancelSubscriptions == 0
                                               && _numCreatePlans == 0
                                               && _numUpdatePlans == 0
                                               && _numActivates == 0
                                               && _numDeactivates == 0
                                               && _numLoads == 0
                                               && _numUnloads == 0
                                               && _numBalanceInquiries == 0
                                               && _numPayFacCredit == 0
                                               && _numSubmerchantCredit == 0
                                               && _numReserveCredit == 0
                                               && _numVendorCredit == 0
                                               && _numPhysicalCheckCredit == 0
                                               && _numPayFacDebit == 0
                                               && _numSubmerchantDebit == 0
                                               && _numReserveDebit == 0
                                               && _numVendorDebit == 0
                                               && _numPhysicalCheckDebit == 0;
    }

    public class RFRRequest
    {
        public long litleSessionId;
        public accountUpdateFileRequestData accountUpdateFileRequestData;

        private litleTime _litleTime;
        private litleFile _litleFile;
        private string _requestDirectory;
        private string _responseDirectory;

        private Dictionary<string, string> _config;
        private readonly IDictionary<string, StringBuilder> _cache;

        public RFRRequest(IDictionary<string, StringBuilder> cache)
        {
            _cache = cache;
            _config = new Dictionary<string, string>
            {
                ["url"] = Settings.Default.url,
                ["reportGroup"] = Settings.Default.reportGroup,
                ["username"] = Settings.Default.username,
                ["printxml"] = Settings.Default.printxml,
                ["timeout"] = Settings.Default.timeout,
                ["proxyHost"] = Settings.Default.proxyHost,
                ["merchantId"] = Settings.Default.merchantId,
                ["password"] = Settings.Default.password,
                ["proxyPort"] = Settings.Default.proxyPort,
                ["sftpUrl"] = Settings.Default.sftpUrl,
                ["sftpUsername"] = Settings.Default.sftpUsername,
                ["sftpPassword"] = Settings.Default.sftpPassword,
                ["knownHostsFile"] = Settings.Default.knownHostsFile,
                ["requestDirectory"] = Settings.Default.requestDirectory,
                ["responseDirectory"] = Settings.Default.responseDirectory
            };

            _litleTime = new litleTime();
            _litleFile = new litleFile(_cache);

            _requestDirectory = _config["requestDirectory"] + "\\Requests\\";
            _responseDirectory = _config["responseDirectory"] + "\\Responses\\";
        }

        public RFRRequest(IDictionary<string, StringBuilder> cache, Dictionary<string, string> config)
        {
            _cache = cache;
            _config = config;

            InitializeRequest();
        }

        private void InitializeRequest()
        {
            _requestDirectory = _config["requestDirectory"] + "\\Requests\\";
            _responseDirectory = _config["responseDirectory"] + "\\Responses\\";

            _litleFile = new litleFile(_cache);
            _litleTime = new litleTime();
        }

        public string getRequestDirectory() => _requestDirectory;

        public string getResponseDirectory() => _responseDirectory;

        public void setConfig(Dictionary<string, string> config) => _config = config;

        public void setLitleFile(litleFile litleFile) => _litleFile = litleFile;

        public litleFile getLitleFile() => _litleFile;

        public void setLitleTime(litleTime litleTime) => _litleTime = litleTime;

        public litleTime getLitleTime() => _litleTime;

        public string Serialize()
        {
            const string xmlHeader = "\r\n<RFRRequest xmlns=\"http://www.litle.com/schema\">";
            const string xmlFooter = "\r\n</RFRRequest>";

            var filePath = _litleFile.createRandomFile(_requestDirectory, null, "_RFRRequest.xml", _litleTime);

            var xmlBody = string.Empty;

            if (accountUpdateFileRequestData != null)
            {
                xmlBody += "\r\n<accountUpdateFileRequestData>";
                xmlBody += accountUpdateFileRequestData.Serialize();
                xmlBody += "\r\n</accountUpdateFileRequestData>";
            }
            else
            {
                xmlBody += "\r\n<litleSessionId>" + litleSessionId + "</litleSessionId>";
            }
            _litleFile.AppendLineToFile(filePath, xmlHeader);
            _litleFile.AppendLineToFile(filePath, xmlBody);
            _litleFile.AppendLineToFile(filePath, xmlFooter);

            return filePath;
        }
    }

    public class echeckPreNoteCredit : transactionTypeWithReportGroup
    {
        /// <remarks />
        public string orderId { get; set; }

        /// <remarks />
        public orderSourceType orderSource { get; set; }

        /// <remarks />
        public contact billToAddress { get; set; }

        /// <remarks />
        public echeckType echeck { get; set; }

        /// <remarks />
        public merchantDataType merchantData { get; set; }

        public override string Serialize()
        {
            var xml = "\r\n<echeckPreNoteCredit ";

            if (id != null)
            {
                xml += "id=\"" + SecurityElement.Escape(id) + "\" ";
            }
            if (customerId != null)
            {
                xml += "customerId=\"" + SecurityElement.Escape(customerId) + "\" ";
            }
            xml += "reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            xml += "\r\n<orderId>" + SecurityElement.Escape(orderId) + "</orderId>";

            if (orderSource != null)
            {
                xml += "\r\n<orderSource>";
                xml += orderSource.Serialize();
                xml += "</orderSource>";
            }

            if (billToAddress != null)
            {
                xml += "\r\n<billToAddress>";
                xml += billToAddress.Serialize();
                xml += "\r\n</billToAddress>";
            }

            if (echeck != null)
            {
                xml += "\r\n<echeck>";
                xml += echeck.Serialize();
                xml += "\r\n</echeck>";
            }

            if (merchantData != null)
            {
                xml += "\r\n<merchantData>";
                xml += merchantData.Serialize();
                xml += "\r\n</merchantData>";
            }

            xml += "\r\n</echeckPreNoteCredit>";

            return xml;
        }
    }

    public class echeckPreNoteSale : transactionTypeWithReportGroup
    {
        /// <remarks />
        public string orderId { get; set; }

        /// <remarks />
        public orderSourceType orderSource { get; set; }

        /// <remarks />
        public contact billToAddress { get; set; }

        /// <remarks />
        public echeckType echeck { get; set; }

        /// <remarks />
        public merchantDataType merchantData { get; set; }

        public override string Serialize()
        {
            var xml = "\r\n<echeckPreNoteSale ";

            if (id != null)
            {
                xml += "id=\"" + SecurityElement.Escape(id) + "\" ";
            }
            if (customerId != null)
            {
                xml += "customerId=\"" + SecurityElement.Escape(customerId) + "\" ";
            }
            xml += "reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            xml += "\r\n<orderId>" + SecurityElement.Escape(orderId) + "</orderId>";

            if (orderSource != null)
            {
                xml += "\r\n<orderSource>";
                xml += orderSource.Serialize();
                xml += "</orderSource>";
            }

            if (billToAddress != null)
            {
                xml += "\r\n<billToAddress>";
                xml += billToAddress.Serialize();
                xml += "\r\n</billToAddress>";
            }

            if (echeck != null)
            {
                xml += "\r\n<echeck>";
                xml += echeck.Serialize();
                xml += "\r\n</echeck>";
            }

            if (merchantData != null)
            {
                xml += "\r\n<merchantData>";
                xml += merchantData.Serialize();
                xml += "\r\n</merchantData>";
            }

            xml += "\r\n</echeckPreNoteSale>";

            return xml;
        }
    }

    public class submerchantCredit : transactionTypeWithReportGroup
    {
        public string fundingSubmerchantId { get; set; }

        public string submerchantName { get; set; }

        public string fundsTransferId { get; set; }

        public long? amount { get; set; }

        public echeckType accountInfo { get; set; }

        public override string Serialize()
        {
            var xml = "\r\n<submerchantCredit ";

            if (id != null)
                xml += "id=\"" + SecurityElement.Escape(id) + "\" ";
            if (customerId != null)
                xml += "customerId=\"" + SecurityElement.Escape(customerId) + "\" ";
            xml += "reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            if (fundingSubmerchantId != null)
                xml += "\r\n<fundingSubmerchantId>" + SecurityElement.Escape(fundingSubmerchantId) +
                       "</fundingSubmerchantId>";
            if (submerchantName != null)
                xml += "\r\n<submerchantName>" + SecurityElement.Escape(submerchantName) + "</submerchantName>";
            if (fundsTransferId != null)
                xml += "\r\n<fundsTransferId>" + SecurityElement.Escape(fundsTransferId) + "</fundsTransferId>";
            if (amount != null)
                xml += "\r\n<amount>" + amount + "</amount>";

            if (accountInfo != null)
            {
                xml += "\r\n<accountInfo>";
                xml += accountInfo.Serialize();
                xml += "</accountInfo>";
            }

            xml += "\r\n</submerchantCredit>";

            return xml;
        }
    }

    public class payFacCredit : transactionTypeWithReportGroup
    {
        public string fundingSubmerchantId { get; set; }

        public string fundsTransferId { get; set; }

        public long? amount { get; set; }

        public override string Serialize()
        {
            var xml = "\r\n<payFacCredit ";

            if (id != null)
                xml += "id=\"" + SecurityElement.Escape(id) + "\" ";
            if (customerId != null)
                xml += "customerId=\"" + SecurityElement.Escape(customerId) + "\" ";
            xml += "reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            if (fundingSubmerchantId != null)
                xml += "\r\n<fundingSubmerchantId>" + SecurityElement.Escape(fundingSubmerchantId) +
                       "</fundingSubmerchantId>";
            if (fundsTransferId != null)
                xml += "\r\n<fundsTransferId>" + SecurityElement.Escape(fundsTransferId) + "</fundsTransferId>";
            if (amount != null)
                xml += "\r\n<amount>" + amount + "</amount>";

            xml += "\r\n</payFacCredit>";

            return xml;
        }
    }

    public class reserveCredit : transactionTypeWithReportGroup
    {
        public string fundingSubmerchantId { get; set; }

        public string fundsTransferId { get; set; }

        public long? amount { get; set; }

        public override string Serialize()
        {
            var xml = "\r\n<reserveCredit ";

            if (id != null)
                xml += "id=\"" + SecurityElement.Escape(id) + "\" ";
            if (customerId != null)
                xml += "customerId=\"" + SecurityElement.Escape(customerId) + "\" ";
            xml += "reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            if (fundingSubmerchantId != null)
                xml += "\r\n<fundingSubmerchantId>" + SecurityElement.Escape(fundingSubmerchantId) +
                       "</fundingSubmerchantId>";
            if (fundsTransferId != null)
                xml += "\r\n<fundsTransferId>" + SecurityElement.Escape(fundsTransferId) + "</fundsTransferId>";
            if (amount != null)
                xml += "\r\n<amount>" + amount + "</amount>";

            xml += "\r\n</reserveCredit>";

            return xml;
        }
    }

    public class vendorCredit : transactionTypeWithReportGroup
    {
        public string fundingSubmerchantId { get; set; }

        public string vendorName { get; set; }

        public string fundsTransferId { get; set; }

        public long? amount { get; set; }

        public echeckType accountInfo { get; set; }

        public override string Serialize()
        {
            var xml = "\r\n<vendorCredit ";

            if (id != null)
                xml += "id=\"" + SecurityElement.Escape(id) + "\" ";
            if (customerId != null)
                xml += "customerId=\"" + SecurityElement.Escape(customerId) + "\" ";
            xml += "reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            if (fundingSubmerchantId != null)
                xml += "\r\n<fundingSubmerchantId>" + SecurityElement.Escape(fundingSubmerchantId) +
                       "</fundingSubmerchantId>";
            if (vendorName != null)
                xml += "\r\n<vendorName>" + SecurityElement.Escape(vendorName) + "</vendorName>";
            if (fundsTransferId != null)
                xml += "\r\n<fundsTransferId>" + SecurityElement.Escape(fundsTransferId) + "</fundsTransferId>";
            if (amount != null)
                xml += "\r\n<amount>" + amount + "</amount>";

            if (accountInfo != null)
            {
                xml += "\r\n<accountInfo>";
                xml += accountInfo.Serialize();
                xml += "</accountInfo>";
            }

            xml += "\r\n</vendorCredit>";

            return xml;
        }
    }

    public class physicalCheckCredit : transactionTypeWithReportGroup
    {
        public string fundingSubmerchantId { get; set; }

        public string fundsTransferId { get; set; }

        public long? amount { get; set; }

        public override string Serialize()
        {
            var xml = "\r\n<physicalCheckCredit ";

            if (id != null)
                xml += "id=\"" + SecurityElement.Escape(id) + "\" ";
            if (customerId != null)
                xml += "customerId=\"" + SecurityElement.Escape(customerId) + "\" ";
            xml += "reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            if (fundingSubmerchantId != null)
                xml += "\r\n<fundingSubmerchantId>" + SecurityElement.Escape(fundingSubmerchantId) +
                       "</fundingSubmerchantId>";
            if (fundsTransferId != null)
                xml += "\r\n<fundsTransferId>" + SecurityElement.Escape(fundsTransferId) + "</fundsTransferId>";
            if (amount != null)
                xml += "\r\n<amount>" + amount + "</amount>";

            xml += "\r\n</physicalCheckCredit>";

            return xml;
        }
    }

    public class submerchantDebit : transactionTypeWithReportGroup
    {
        public string fundingSubmerchantId { get; set; }

        public string submerchantName { get; set; }

        public string fundsTransferId { get; set; }

        public long? amount { get; set; }

        public echeckType accountInfo { get; set; }

        public override string Serialize()
        {
            var xml = "\r\n<submerchantDebit ";

            if (id != null)
                xml += "id=\"" + SecurityElement.Escape(id) + "\" ";
            if (customerId != null)
                xml += "customerId=\"" + SecurityElement.Escape(customerId) + "\" ";
            xml += "reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            if (fundingSubmerchantId != null)
                xml += "\r\n<fundingSubmerchantId>" + SecurityElement.Escape(fundingSubmerchantId) +
                       "</fundingSubmerchantId>";
            if (submerchantName != null)
                xml += "\r\n<submerchantName>" + SecurityElement.Escape(submerchantName) + "</submerchantName>";
            if (fundsTransferId != null)
                xml += "\r\n<fundsTransferId>" + SecurityElement.Escape(fundsTransferId) + "</fundsTransferId>";
            if (amount != null)
                xml += "\r\n<amount>" + amount + "</amount>";

            if (accountInfo != null)
            {
                xml += "\r\n<accountInfo>";
                xml += accountInfo.Serialize();
                xml += "</accountInfo>";
            }

            xml += "\r\n</submerchantDebit>";

            return xml;
        }
    }

    public class payFacDebit : transactionTypeWithReportGroup
    {
        public string fundingSubmerchantId { get; set; }

        public string fundsTransferId { get; set; }

        public long? amount { get; set; }

        public override string Serialize()
        {
            var xml = "\r\n<payFacDebit ";

            if (id != null)
                xml += "id=\"" + SecurityElement.Escape(id) + "\" ";
            if (customerId != null)
                xml += "customerId=\"" + SecurityElement.Escape(customerId) + "\" ";
            xml += "reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            if (fundingSubmerchantId != null)
                xml += "\r\n<fundingSubmerchantId>" + SecurityElement.Escape(fundingSubmerchantId) +
                       "</fundingSubmerchantId>";
            if (fundsTransferId != null)
                xml += "\r\n<fundsTransferId>" + SecurityElement.Escape(fundsTransferId) + "</fundsTransferId>";
            if (amount != null)
                xml += "\r\n<amount>" + amount + "</amount>";

            xml += "\r\n</payFacDebit>";

            return xml;
        }
    }

    public class reserveDebit : transactionTypeWithReportGroup
    {
        public string fundingSubmerchantId { get; set; }

        public string fundsTransferId { get; set; }

        public long? amount { get; set; }

        public override string Serialize()
        {
            var xml = "\r\n<reserveDebit ";

            if (id != null)
                xml += "id=\"" + SecurityElement.Escape(id) + "\" ";
            if (customerId != null)
                xml += "customerId=\"" + SecurityElement.Escape(customerId) + "\" ";
            xml += "reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            if (fundingSubmerchantId != null)
                xml += "\r\n<fundingSubmerchantId>" + SecurityElement.Escape(fundingSubmerchantId) +
                       "</fundingSubmerchantId>";
            if (fundsTransferId != null)
                xml += "\r\n<fundsTransferId>" + SecurityElement.Escape(fundsTransferId) + "</fundsTransferId>";
            if (amount != null)
                xml += "\r\n<amount>" + amount + "</amount>";

            xml += "\r\n</reserveDebit>";

            return xml;
        }
    }

    public class vendorDebit : transactionTypeWithReportGroup
    {
        public string fundingSubmerchantId { get; set; }

        public string vendorName { get; set; }

        public string fundsTransferId { get; set; }

        public long? amount { get; set; }

        public echeckType accountInfo { get; set; }

        public override string Serialize()
        {
            var xml = "\r\n<vendorDebit ";

            if (id != null)
                xml += "id=\"" + SecurityElement.Escape(id) + "\" ";
            if (customerId != null)
                xml += "customerId=\"" + SecurityElement.Escape(customerId) + "\" ";
            xml += "reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            if (fundingSubmerchantId != null)
                xml += "\r\n<fundingSubmerchantId>" + SecurityElement.Escape(fundingSubmerchantId) +
                       "</fundingSubmerchantId>";
            if (vendorName != null)
                xml += "\r\n<vendorName>" + SecurityElement.Escape(vendorName) + "</vendorName>";
            if (fundsTransferId != null)
                xml += "\r\n<fundsTransferId>" + SecurityElement.Escape(fundsTransferId) + "</fundsTransferId>";
            if (amount != null)
                xml += "\r\n<amount>" + amount + "</amount>";

            if (accountInfo != null)
            {
                xml += "\r\n<accountInfo>";
                xml += accountInfo.Serialize();
                xml += "</accountInfo>";
            }

            xml += "\r\n</vendorDebit>";

            return xml;
        }
    }

    public class physicalCheckDebit : transactionTypeWithReportGroup
    {
        public string fundingSubmerchantId { get; set; }

        public string fundsTransferId { get; set; }

        public long? amount { get; set; }

        public override string Serialize()
        {
            var xml = "\r\n<physicalCheckDebit ";

            if (id != null)
                xml += "id=\"" + SecurityElement.Escape(id) + "\" ";
            if (customerId != null)
                xml += "customerId=\"" + SecurityElement.Escape(customerId) + "\" ";
            xml += "reportGroup=\"" + SecurityElement.Escape(reportGroup) + "\">";
            if (fundingSubmerchantId != null)
                xml += "\r\n<fundingSubmerchantId>" + SecurityElement.Escape(fundingSubmerchantId) +
                       "</fundingSubmerchantId>";
            if (fundsTransferId != null)
                xml += "\r\n<fundsTransferId>" + SecurityElement.Escape(fundsTransferId) + "</fundsTransferId>";
            if (amount != null)
                xml += "\r\n<amount>" + amount + "</amount>";

            xml += "\r\n</physicalCheckDebit>";

            return xml;
        }
    }
}