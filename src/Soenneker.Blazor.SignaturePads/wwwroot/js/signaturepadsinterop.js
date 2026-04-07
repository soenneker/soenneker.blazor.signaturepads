const signaturePadInstances = new Map();
const signatureResizeObservers = new Map();

export function create(canvas, elementId, options) {
        if (!canvas)
            throw new Error("A canvas element reference is required.");

        destroy(elementId);

        resizeSignatureCanvas(canvas);

        const signaturePad = new window.SignaturePad(canvas, options ?? {});

        signaturePadInstances.set(elementId, {
            canvas,
            signaturePad
        });
}
export function createResizeObserver(elementId, preserveDrawingOnResize = true) {
        const instance = getSignaturePadEntry(elementId);

        destroyResizeObserver(elementId);

        const observer = new ResizeObserver(() => {
            resizeSignatureCanvas(instance.canvas, instance.signaturePad, preserveDrawingOnResize);
        });

        observer.observe(instance.canvas);
        signatureResizeObservers.set(elementId, observer);
    };
export function destroyResizeObserver(elementId) {
        const observer = signatureResizeObservers.get(elementId);

        if (!observer)
            return;

        observer.disconnect();
        signatureResizeObservers.delete(elementId);
    };
export function destroy(elementId) {
        destroyResizeObserver(elementId);

        const instance = signaturePadInstances.get(elementId);

        if (!instance)
            return;

        instance.signaturePad.off();
        signaturePadInstances.delete(elementId);
    };
export function clear(elementId) {
        getSignaturePadEntry(elementId).signaturePad.clear();
    };
export function isEmpty(elementId) {
        return getSignaturePadEntry(elementId).signaturePad.isEmpty();
    };
export function toDataUrl(elementId, type = "image/png", encoderOptions = null) {
        return getSignaturePadEntry(elementId).signaturePad.toDataURL(type, encoderOptions ?? undefined);
    };
export function toSvg(elementId, options = null) {
        return getSignaturePadEntry(elementId).signaturePad.toSVG(options ?? undefined);
    };
export function toData(elementId) {
        const data = getSignaturePadEntry(elementId).signaturePad.toData();

        return data.map((group) => ({
            PenColor: group.penColor,
            DotSize: group.dotSize,
            MinWidth: group.minWidth,
            MaxWidth: group.maxWidth,
            VelocityFilterWeight: group.velocityFilterWeight,
            CompositeOperation: group.compositeOperation,
            Points: (group.points ?? []).map((point) => ({
                Time: point.time,
                X: point.x,
                Y: point.y,
                Pressure: point.pressure
            }))
        }));
    };
export function fromData(elementId, data, clear = true) {
        const normalized = (data ?? []).map((group) => ({
            penColor: group.PenColor ?? group.penColor,
            dotSize: group.DotSize ?? group.dotSize,
            minWidth: group.MinWidth ?? group.minWidth,
            maxWidth: group.MaxWidth ?? group.maxWidth,
            velocityFilterWeight: group.VelocityFilterWeight ?? group.velocityFilterWeight,
            compositeOperation: group.CompositeOperation ?? group.compositeOperation,
            points: (group.Points ?? group.points ?? []).map((point) => ({
                time: point.Time ?? point.time,
                x: point.X ?? point.x,
                y: point.Y ?? point.y,
                pressure: point.Pressure ?? point.pressure ?? 0
            }))
        }));

        getSignaturePadEntry(elementId).signaturePad.fromData(normalized, { clear });
    };
export async function fromDataUrl(elementId, dataUrl, options = null) {
        await getSignaturePadEntry(elementId).signaturePad.fromDataURL(dataUrl, options ?? undefined);
    };
export function redraw(elementId) {
        getSignaturePadEntry(elementId).signaturePad.redraw();
    };
export function on(elementId) {
        getSignaturePadEntry(elementId).signaturePad.on();
    };
export function off(elementId) {
        getSignaturePadEntry(elementId).signaturePad.off();
    };
export function setOptions(elementId, options) {
        if (!options)
            return;

        const signaturePad = getSignaturePadEntry(elementId).signaturePad;

        if (options.dotSize !== undefined)
            signaturePad.dotSize = options.dotSize;

        if (options.minWidth !== undefined)
            signaturePad.minWidth = options.minWidth;

        if (options.maxWidth !== undefined)
            signaturePad.maxWidth = options.maxWidth;

        if (options.throttle !== undefined)
            signaturePad.throttle = options.throttle;

        if (options.minDistance !== undefined)
            signaturePad.minDistance = options.minDistance;

        if (options.backgroundColor !== undefined)
            signaturePad.backgroundColor = options.backgroundColor;

        if (options.penColor !== undefined)
            signaturePad.penColor = options.penColor;

        if (options.velocityFilterWeight !== undefined)
            signaturePad.velocityFilterWeight = options.velocityFilterWeight;

        if (options.compositeOperation !== undefined)
            signaturePad.compositeOperation = options.compositeOperation;

        if (signaturePad.isEmpty())
            signaturePad.clear();
    };
function getSignaturePadEntry(elementId) {
        const instance = signaturePadInstances.get(elementId);

        if (!instance)
            throw new Error(`SignaturePad instance '${elementId}' was not found.`);

        return instance;
    };
function resizeSignatureCanvas(canvas, signaturePad = null, preserveDrawing = true) {
        const width = getSignatureCanvasWidth(canvas);
        const height = getSignatureCanvasHeight(canvas);
        const ratio = Math.max(window.devicePixelRatio || 1, 1);

        if (width <= 0 || height <= 0)
            return;

        const scaledWidth = Math.floor(width * ratio);
        const scaledHeight = Math.floor(height * ratio);

        if (canvas.width === scaledWidth && canvas.height === scaledHeight)
            return;

        const data = signaturePad && preserveDrawing && !signaturePad.isEmpty()
            ? signaturePad.toData()
            : null;

        canvas.width = scaledWidth;
        canvas.height = scaledHeight;

        const context = canvas.getContext("2d");
        context.scale(ratio, ratio);

        if (!signaturePad)
            return;

        if (data && data.length > 0)
            signaturePad.fromData(data);
        else
            signaturePad.clear();
    };
function getSignatureCanvasWidth(canvas) {
        return canvas.offsetWidth || canvas.clientWidth || Number.parseInt(canvas.getAttribute("width") ?? "0", 10) || 300;
    };
function getSignatureCanvasHeight(canvas) {
        return canvas.offsetHeight || canvas.clientHeight || Number.parseInt(canvas.getAttribute("height") ?? "0", 10) || 150;
    };
