# Errorhandling Service

```plantuml

package BackgroundService{
    class CallBackService{
        + GetError
    }
    class InitialBackgroundService{}
}

package DatabaseCollectionHandler {
    class DatatbaseHandler{
    }
    
    interface IDatabaseHandler{
    }
}

package WarningReportService{
    class WarningReport{
        + PostWarningReportRequest
        + GetWarningReportRequest
    }

    class PrometheusService{}

    class GrafanaService{}
    Interface IWarningReport{}
}

package DataModel{
    class WarningModel{
        +int request_id {get; set;}
        +timestamp start_time {get; set;}
        +string mission_id {get; set;}
        +string task_id {get; set;}
        +string device_id {get; set;}
        +string error_code {get; set;}
        +string warning_content {get; set;}
        +string firm_id {get; set;}
        +string version {get; set;}
    }
}


DatatbaseHandler..|>IDatabaseHandler
WarningReport..|>IWarningReport

IDatabaseHandler <-- WarningReport
IDatabaseHandler <-- PrometheusService
PrometheusService <-- GrafanaService

WarningReport - DataModel

```