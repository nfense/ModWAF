<p align="center">
  <img src="https://github.com/nfense/ModWaf/blob/main/assets/icon.png?raw=true"/>
  <h1 align="center">ModWAF</h1>
  <p align="center">Web Application Firewall Module for NProxy that prevents common XSS, SQLi, LFi and RCE exploit attacks</p>
</p>

## ⚠️ Disclaimer

This project is still in development and is not ready for production use. This is not optimized and may be unstable. Use only in development or test environments.

## 🛡️ About

ModWAF is an NProxy module which implements a WAF (Web Application Firewall) focused on mitigating common attack patterns of XSS, SQLi, RCE and LFI.

## ToDo

### Hooks

- [ ] Cookies.  
- [ ] Request Body.  
- [ ] URL Path.  
- [ ] URL Query.  

### Input Pattern Based Modules

- [x] Regex base Detection.  
- [ ] XSS Detection.  
- [ ] SQL Injection Detection.  
- [ ] Remote Code Execution Detection.  
- [ ] Local File Inclusion Detection.  

### Header Based Modules

- [ ] CSP Header.  
- [ ] CORS Header.  
- [ ] X-Frame-Options Header.  
- [ ] X-XSS-Protection Header.  
- [ ] HSTS Header.  
- [ ] X-Content-Type-Options Header.  
- [ ] X-DNS-Prefetch-Control Header.  
- [ ] Referrer-Policy Header.  
- [ ] X-Permitted-Cross-Domain-Policies Header.  
- [ ] Expect-CT Header.  

### Misc Modules

- [ ] Hide Server Branding.  
