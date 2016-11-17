using Autofac;
using DataHarmonizationProcessor.Business;
using DataHarmonizationProcessor.Configuration;
using NLog;
using NLog.Internal;
using System;
using System.Timers;
using DataHarmonizationProcessor.Business.Logging;
using DataHarmonizationProcessor.Business.Managers;
using DataHarmonizationProcessor.Business.Services;
using DataHarmonizationProcessor.Data.Repositories;
using Topshelf;
using Topshelf.Hosts;

namespace DataHarmonizationProcessor.Application
{
    internal class DataHarmonizationService : ServiceControl
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly Timer _pollingTimer;
        private static IConfigurationManager _configurationManager = new ConfigurationManager();
        private readonly TimeSpan _timeSpanInterval = TimeSpan.FromSeconds(Convert.ToDouble(_configurationManager.AppSettings["pollInterval"]));
        private IServiceManager _serviceManager;

        public DataHarmonizationService()
        {
            //Instantiate timers
            _pollingTimer = new Timer(_timeSpanInterval.TotalMilliseconds) { AutoReset = false };
            _pollingTimer.Elapsed += ActivateService;
            _serviceManager = new ServiceManager(new DataHarmonizationLogManager(), new DataHarmonizationQueueService(new DataHarmonizationQueueRepository(), new DataHarmonizationLogManager()),new DataProcessorService(new TimeSpanUtil()),new DataHarmonizationManager(new DataHarmonizationLogManager(), new LicenseRepository(), new DataHarmonizationQueueService(new DataHarmonizationQueueRepository(), new DataHarmonizationLogManager()),new LicenseProductService(new DataHarmonizationLogManager()),new SnapshotManager(new SnapshotLicenseManager(new SnapshotLicenseRepository(), new SnapshotComposerOriginalPublisherAdminKnownAsRepository(), new SnapshotComposerRepository(), new SnapshotComposerAffiliationRepository(), new SnapshotComposerAffiliationBaseRepository(), new Snapshot_ComposerKnownAsRepository(), new SnapshotComposerOriginalPublisherAffiliationBaseRepository(), new Snapshot_ComposerOriginalPublisherAffiliationRepository(), new Snapshot_ComposerOriginalPublisherRepository(),  new Snapshot_ComposerOriginalPublisherKnownAsRepository(), new SnapshotSampleAquisitionLocationCodeRepository(), new SnapshotSampleLocalClientCopyrightRepository(), new SnapshotComposerOriginalPublisherAdministratorRepository(), new SnapshotComposerOriginalPublisherAdminAffiliationRepository(), new SnapshotComposerOriginalPublisherAdminAffiliationBaseRepository(), new SnapshotOriginalPubAffiliationBaseRepository(), new SnapshotAffiliationBaseRepository(), new SnapshotOriginalPublisherAffiliationRepository(), new SnapshotAdminAffiliationBaseRepository(), new SnapshotAdminAffiliationRepository(), new SnapshotAdminKnownAsRepository(), new SnapshotAdministratorRepository(), new LicenseProductConfigurationRepository(), new SnapshotAquisitionLocationCodeRepository(), new SnapshotRecsCopyrightRespository(), new SnapshotSampleRepository(), new SnapshotOriginalPublisherRepository(), new SnapshotKnownAsRepository(), new SnapshotAffiliationRepository(), new SnapshotWorksWriterRepository(), new SnapshotWorkTrackRepository(), new SnapshotLicenseProductRepository(), new SnapshotWorksRecordingRepository(), new SnapshotRecsConfigurationRepository(), new SnapshotProductHeaderRepository(), new SnapshotConfigurationRepository(), new SnapshotArtistRecsRepository(), new SnapshotLabelRepository(), new SnapshotLabelGroupRepository(), new SnapshotLocalClientCopyrightRepository()),new SnapshotLicenseProductManager(new SnapshotLicenseRepository(), new SnapshotComposerOriginalPublisherAdminKnownAsRepository(), new SnapshotComposerRepository(), new SnapshotComposerAffiliationRepository(), new SnapshotComposerAffiliationBaseRepository(), new Snapshot_ComposerKnownAsRepository(), new SnapshotComposerOriginalPublisherAffiliationBaseRepository(), new Snapshot_ComposerOriginalPublisherAffiliationRepository(), new Snapshot_ComposerOriginalPublisherRepository(), new Snapshot_ComposerOriginalPublisherKnownAsRepository(), new SnapshotSampleRepository(), new SnapshotSampleAquisitionLocationCodeRepository(), new SnapshotSampleLocalClientCopyrightRepository(), new SnapshotComposerOriginalPublisherAdministratorRepository(), new SnapshotComposerOriginalPublisherAdminAffiliationRepository(), new SnapshotComposerOriginalPublisherAdminAffiliationBaseRepository(), new SnapshotOriginalPubAffiliationBaseRepository(), new SnapshotOriginalPublisherAffiliationRepository(), new SnapshotAffiliationBaseRepository(), new SnapshotAdminKnownAsRepository(), new SnapshotAdminAffiliationBaseRepository(), new SnapshotAdminAffiliationRepository(), new SnapshotAdministratorRepository(), new SnapshotAquisitionLocationCodeRepository(), new SnapshotRecsCopyrightRespository(), new SnapshotOriginalPublisherRepository(), new SnapshotKnownAsRepository(), new SnapshotAffiliationRepository(), new SnapshotWorksWriterRepository(), new SnapshotWorkTrackRepository(), new SnapshotLicenseProductRepository(), new SnapshotWorksRecordingRepository(), new SnapshotRecsConfigurationRepository(), new SnapshotProductHeaderRepository(), new SnapshotConfigurationRepository(), new SnapshotArtistRecsRepository(), new SnapshotLabelRepository(), new SnapshotLabelGroupRepository(), new SnapshotLocalClientCopyrightRepository()) )  )  );
        }

        private void ActivateService(object sender, System.Timers.ElapsedEventArgs e)
        {
            Logger.Debug("*********DataHarmonization processor activated.*********");

            Console.WriteLine(_timeSpanInterval.TotalSeconds);

          
       
            _serviceManager.ProcessQueue();

            _pollingTimer.Start();
        }

        #region ServiceControl Members

        public bool Start(HostControl hostControl)
        {
            Logger.Debug("***DataHarmonization service starts.***");
            Console.WriteLine("Is running as console: " + IsRunningAsConsole(hostControl));
            try
            {
                _pollingTimer.Start();
                Logger.Info("__ PollingTimer Started*");
            }
            catch (Exception failPollingException)
            {
                Logger.ErrorException("*****************Cannot start DataHarmonization service.", failPollingException);

                return false;
            }
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            Logger.Info("*************DataHarmonization service terminated.**************");
            return true;
        }

        private static bool IsRunningAsConsole(HostControl control)
        {
            return control is ConsoleRunHost;
        }

        #endregion ServiceControl Members
    }
}