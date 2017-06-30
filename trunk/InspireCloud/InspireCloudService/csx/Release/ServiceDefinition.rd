<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="InspireCloudService" generation="1" functional="0" release="0" Id="f50159cd-f61a-47f9-b326-ff6cc8e7709b" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="InspireCloudServiceGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="WeatherServiceWebRole:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/InspireCloudService/InspireCloudServiceGroup/LB:WeatherServiceWebRole:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="WeatherServiceWebRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/InspireCloudService/InspireCloudServiceGroup/MapWeatherServiceWebRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="WeatherServiceWebRoleInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/InspireCloudService/InspireCloudServiceGroup/MapWeatherServiceWebRoleInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:WeatherServiceWebRole:Endpoint1">
          <toPorts>
            <inPortMoniker name="/InspireCloudService/InspireCloudServiceGroup/WeatherServiceWebRole/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapWeatherServiceWebRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/InspireCloudService/InspireCloudServiceGroup/WeatherServiceWebRole/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapWeatherServiceWebRoleInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/InspireCloudService/InspireCloudServiceGroup/WeatherServiceWebRoleInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="WeatherServiceWebRole" generation="1" functional="0" release="0" software="C:\CODE\trunk\InspireCloud\InspireCloudService\csx\Release\roles\WeatherServiceWebRole" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="-1" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;WeatherServiceWebRole&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;WeatherServiceWebRole&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/InspireCloudService/InspireCloudServiceGroup/WeatherServiceWebRoleInstances" />
            <sCSPolicyUpdateDomainMoniker name="/InspireCloudService/InspireCloudServiceGroup/WeatherServiceWebRoleUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/InspireCloudService/InspireCloudServiceGroup/WeatherServiceWebRoleFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="WeatherServiceWebRoleUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="WeatherServiceWebRoleFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="WeatherServiceWebRoleInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="1d39626d-e96a-4092-bc84-654370331fe3" ref="Microsoft.RedDog.Contract\ServiceContract\InspireCloudServiceContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="2aeef954-31e9-4718-97f6-214e45aa4c35" ref="Microsoft.RedDog.Contract\Interface\WeatherServiceWebRole:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/InspireCloudService/InspireCloudServiceGroup/WeatherServiceWebRole:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>